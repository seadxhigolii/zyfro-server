using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Application.Interfaces.AWS;
using Zyfro.Pro.Server.Application.Models.Document;
using Zyfro.Pro.Server.Common.Helpers;
using Zyfro.Pro.Server.Common.Response;
using Zyfro.Pro.Server.Domain.Entities;

namespace Zyfro.Pro.Server.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IProDbContext _proDbContext;
        private readonly IS3Service _s3Service;
        private readonly IMapper _mapper;
        public DocumentService(IProDbContext proDbContext, IS3Service s3Service, IMapper mapper)
        {
            _proDbContext = proDbContext;
            _s3Service = s3Service;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<Document>>> GetAllDocuments()
        {
            Guid currentUserId = Guid.Parse(AuthHelper.GetCurrentUserId());
            var data = await _proDbContext.Documents.Where(x => x.OwnerId == currentUserId).ToListAsync();

            return ServiceResponse<List<Document>>.SuccessResponse(data, "Success", 200);
        }

        public async Task<ServiceResponse<Document>> GetDocumentById(Guid id)
        {
            var data = await _proDbContext.Documents.FindAsync(id);

            return ServiceResponse<Document>.SuccessResponse(data, "Success", 200);
        }
        public async Task<ServiceResponse<bool>> CreateDocument(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return ServiceResponse<bool>.ErrorResponse("Invalid file", 400);

            Guid currentUserId = Guid.Parse(AuthHelper.GetCurrentUserId());
            string currentCompanyId = AuthHelper.GetCurrentCompanyId();
            DateTime now = DateTime.UtcNow;

            string documentId = Guid.NewGuid().ToString();
            int version = 1;
            string key = $"company-{currentCompanyId}/user-{currentUserId}/documents/{documentId}/versions/{version}/{now:yyyy/MM/dd}/{file.FileName}";

            var uploadResult = await _s3Service.UploadFileAsync(file, key);

            if (!string.IsNullOrEmpty(uploadResult))
            {
                var document = new Document
                {
                    Id = Guid.NewGuid(),
                    OwnerId = currentUserId,
                    CreatedAtUtc = now,
                    FilePath = key,
                    Name = Path.GetFileNameWithoutExtension(file.FileName),
                    ContentType = file.ContentType,
                    FileSize = file.Length,
                    IsArchived = false
                };

                await _proDbContext.Documents.AddAsync(document);
                await _proDbContext.SaveChangesAsync();

                await UpdateDirectoryMetadata(currentCompanyId, currentUserId.ToString(), documentId, version.ToString(), now, file.FileName);

                return ServiceResponse<bool>.SuccessResponse(true, "Document Uploaded Successfully", 200);
            }

            return ServiceResponse<bool>.ErrorResponse("Document Upload Failed", 500);
        }

        public async Task<ServiceResponse<bool>> SoftDeleteDocument(Guid documentId)
        {
            var document = await _proDbContext.Documents.FindAsync(documentId);
            if (document == null)
                return ServiceResponse<bool>.ErrorResponse("Document not found", 404);

            document.Deleted = true;
            await _proDbContext.SaveChangesAsync();

            await UpdateDocumentStatusInMetadata(document, isDeleted: true);

            return ServiceResponse<bool>.SuccessResponse(true, "Document soft deleted", 200);
        }


        private async Task UpdateDirectoryMetadata(string companyId, string userId, string documentId, string version, DateTime date, string fileName)
        {
            var pathsToUpdate = new List<string>
            {
                $"company-{companyId}/metadata.json",
                $"company-{companyId}/user-{userId}/metadata.json",
                $"company-{companyId}/user-{userId}/documents/{documentId}/metadata.json",
                $"company-{companyId}/user-{userId}/documents/{documentId}/versions/{version}/metadata.json",
                $"company-{companyId}/user-{userId}/documents/{documentId}/versions/{version}/{date:yyyy/MM/dd}/metadata.json"
            };

            foreach (var path in pathsToUpdate)
            {
                await UpdateMetadataFile(path, companyId, userId, documentId, version, date, fileName);
            }
        }

        private async Task UpdateMetadataFile(string metadataKey, string companyId, string userId, string documentId, string version, DateTime date, string fileName)
        {
            List<object> metadataList;

            try
            {
                var existingData = await _s3Service.DownloadFileAsync(metadataKey);
                var existingJson = Encoding.UTF8.GetString(existingData);
                metadataList = JsonSerializer.Deserialize<List<object>>(existingJson) ?? new List<object>();
            }
            catch
            {
                metadataList = new List<object>();
            }

            bool exists = metadataList.Any(item => JsonSerializer.Serialize(item).Contains(documentId) && JsonSerializer.Serialize(item).Contains(fileName));
            if (!exists)
            {
                var newEntry = new
                {
                    CompanyId = companyId,
                    UserId = userId,
                    DocumentId = documentId,
                    Version = version,
                    Date = date.ToString("yyyy-MM-dd"),
                    FileName = fileName
                };

                metadataList.Add(newEntry);
            }

            var metadataJson = JsonSerializer.Serialize(metadataList);
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(metadataJson)))
            {
                var formFile = new FormFile(stream, 0, stream.Length, "metadata", "metadata.json")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/json"
                };

                await _s3Service.UploadFileAsync(formFile, metadataKey);
            }
        }

        private async Task UpdateDocumentStatusInMetadata(Document document, bool? isArchived = null, bool? isDeleted = null)
        {
            var metadataKey = $"company-{document.CompanyId}/user-{document.OwnerId}/documents/{document.Id}/metadata.json";
            var metadataData = await _s3Service.DownloadFileAsync(metadataKey);
            var metadataList = JsonSerializer.Deserialize<List<dynamic>>(Encoding.UTF8.GetString(metadataData)) ?? new List<dynamic>();

            foreach (var item in metadataList)
            {
                if (item.DocumentId == document.Id.ToString())
                {
                    if (isArchived.HasValue) item.IsArchived = isArchived.Value;
                    if (isDeleted.HasValue) item.IsDeleted = isDeleted.Value;
                }
            }

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(metadataList))))
            {
                var formFile = new FormFile(stream, 0, stream.Length, "metadata", "metadata.json")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/json"
                };

                await _s3Service.UploadFileAsync(formFile, metadataKey);
            }
        }

    }
}
