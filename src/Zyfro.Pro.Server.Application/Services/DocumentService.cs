﻿using AutoMapper;
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
using Zyfro.Pro.Server.Domain.Enums;

namespace Zyfro.Pro.Server.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IProDbContext _proDbContext;
        private readonly IS3Service _s3Service;
        private readonly ISecretService _secretService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        public DocumentService(IProDbContext proDbContext, IS3Service s3Service, IMapper mapper, ISecretService secretService, ICacheService cacheService)
        {
            _proDbContext = proDbContext;
            _s3Service = s3Service;
            _mapper = mapper;
            _secretService = secretService;
            _cacheService = cacheService;
        }
        public async Task<ServiceResponse<List<Document>>> GetAllDocuments()
        {
            Guid currentUserId = Guid.Parse(AuthHelper.GetCurrentUserId());

            var data = await _proDbContext.Documents.Where(x => x.OwnerId == currentUserId).ToListAsync();

            return ServiceResponse<List<Document>>.SuccessResponse(data, "Success");
        }

        public async Task<ServiceResponse<Document>> GetDocumentById(Guid id)
        {
            var data = await _proDbContext.Documents.FindAsync(id);

            return ServiceResponse<Document>.SuccessResponse(data, "Success");
        }
        public async Task<ServiceResponse<bool>> CreateDocument(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return ServiceResponse<bool>.ErrorResponse("Invalid file");

            Guid currentUserId = Guid.Parse(AuthHelper.GetCurrentUserId());
            string currentCompanyId = AuthHelper.GetCurrentCompanyId();
            DateTime now = DateTime.UtcNow;

            Guid documentId = Guid.NewGuid();
            int version = 1;
            string key = $"company-{currentCompanyId}/user-{currentUserId}/documents/{documentId}/versions/{version}/{now:yyyy/MM/dd}/{file.FileName}";

            var uploadResult = await _s3Service.UploadFileAsync(file, key);

            if (!string.IsNullOrEmpty(uploadResult))
            {
                var document = new Document
                {
                    Id = documentId,
                    OwnerId = currentUserId,
                    CreatedAtUtc = now,
                    FilePath = key,
                    Name = Path.GetFileNameWithoutExtension(file.FileName),
                    ContentType = file.ContentType,
                    FileSize = file.Length,
                    CompanyId = Guid.Parse(currentCompanyId),
                    CurrentVersion = version,
                };

                await _proDbContext.Documents.AddAsync(document);
                await _proDbContext.SaveChangesAsync();

                var documentVersion = new DocumentVersion
                {
                    Id = Guid.NewGuid(),
                    DocumentId = document.Id,
                    FilePath = key,
                    VersionNumber = version
                };

                await _proDbContext.DocumentVersions.AddAsync(documentVersion);
                await _proDbContext.SaveChangesAsync();

                await UpdateCompanyMetadata(currentCompanyId, currentUserId.ToString(), documentId.ToString(), version.ToString(), now, file.FileName, "Created");

                return ServiceResponse<bool>.SuccessResponse(true, "Document uploaded successfully", 200);
            }

            return ServiceResponse<bool>.InternalErrorResponse("Document upload failed");
        }

        public async Task<ServiceResponse<bool>> ArchiveDocument(Guid documentId)
        {
            var document = await _proDbContext.Documents.FindAsync(documentId);
            if (document == null)
                return ServiceResponse<bool>.NotFoundErrorResponse("Document not found");

            document.CurrentStatus = EntityStatus.Archived;
            await _proDbContext.SaveChangesAsync();

            await UpdateDocumentStatusInMetadata(AuthHelper.GetCurrentCompanyId(), documentId.ToString(), "Archived");

            return ServiceResponse<bool>.SuccessResponse(true, "Document archived");
        }
        public async Task<ServiceResponse<bool>> UnarchiveDocument(Guid documentId)
        {
            var document = await _proDbContext.Documents.FindAsync(documentId);
            if (document == null)
                return ServiceResponse<bool>.NotFoundErrorResponse("Document not found");

            document.CurrentStatus = EntityStatus.Modified;
            await _proDbContext.SaveChangesAsync();

            await UpdateDocumentStatusInMetadata(AuthHelper.GetCurrentCompanyId(), documentId.ToString(), "Modified");


            return ServiceResponse<bool>.SuccessResponse(true, "Document unarchived");
        }

        public async Task<ServiceResponse<bool>> SoftDeleteDocument(Guid documentId)
        {
            var document = await _proDbContext.Documents.FindAsync(documentId);
            if (document == null)
                return ServiceResponse<bool>.NotFoundErrorResponse("Document not found");

            document.CurrentStatus = EntityStatus.Deleted;
            await _proDbContext.SaveChangesAsync();

            await UpdateDocumentStatusInMetadata(AuthHelper.GetCurrentCompanyId(), documentId.ToString(), "Deleted");

            return ServiceResponse<bool>.SuccessResponse(true, "Document deleted");
        }

        public async Task<ServiceResponse<bool>> UpdateDocument(Guid id, IFormFile newFile)
        {
            if (newFile == null || newFile.Length == 0)
                return ServiceResponse<bool>.ErrorResponse("Invalid file");

            var existingDocument = await _proDbContext.Documents.FindAsync(id);
            if (existingDocument == null)
                return ServiceResponse<bool>.NotFoundErrorResponse("Document not found");

            Guid currentUserId = existingDocument.OwnerId;
            string currentCompanyId = existingDocument.CompanyId.ToString();
            DateTime now = DateTime.UtcNow;

            int newVersion = existingDocument.CurrentVersion + 1;
            Guid newDocumentId = Guid.NewGuid();
            string newKey = $"company-{currentCompanyId}/user-{currentUserId}/documents/{existingDocument.Id}/versions/{newVersion}/{now:yyyy/MM/dd}/{newFile.FileName}";

            var uploadResult = await _s3Service.UploadFileAsync(newFile, newKey);
            if (string.IsNullOrEmpty(uploadResult))
                return ServiceResponse<bool>.InternalErrorResponse("Failed to upload new document version");

            existingDocument.CurrentVersion = newVersion;
            existingDocument.FilePath = newKey;
            existingDocument.CurrentStatus = EntityStatus.Modified;

            _proDbContext.Documents.Update(existingDocument);
            await _proDbContext.SaveChangesAsync();

            var existingDocumentVersions = await _proDbContext.DocumentVersions
                                                .Where(x => x.DocumentId == existingDocument.Id && x.CurrentStatus != EntityStatus.Archived)
                                                .ToListAsync();

            foreach(var docVersion in existingDocumentVersions)
            {
                docVersion.CurrentStatus = EntityStatus.Archived;
            }

            _proDbContext.DocumentVersions.UpdateRange(existingDocumentVersions);

            var newDocumentVersion = new DocumentVersion
            {
                Id = Guid.NewGuid(),
                DocumentId = existingDocument.Id,
                VersionNumber = newVersion,
                FilePath = newKey
            };

            await _proDbContext.DocumentVersions.AddAsync(newDocumentVersion);
            await _proDbContext.SaveChangesAsync();

            await UpdateCompanyMetadata(currentCompanyId, currentUserId.ToString(), existingDocument.Id.ToString(), newVersion.ToString(), now, newFile.FileName, "Modified");

            return ServiceResponse<bool>.SuccessResponse(true, "Document updated successfully");
        }

        public async Task<ServiceResponse<bool>> AddTagsToDocument(Guid documentId, string[] tags)
        {
            var document = await _proDbContext.Documents.FindAsync(documentId);
            if (document == null)
                return ServiceResponse<bool>.NotFoundErrorResponse("Document not found");

            var existingTags = await _proDbContext.DocumentTags
                .Where(dt => dt.DocumentId == documentId)
                .Select(dt => dt.Tag)
                .ToListAsync();

            var newTags = tags.Except(existingTags).ToList();

            if (newTags.Any())
            {
                var documentTags = newTags.Select(tag => new DocumentTag
                {
                    Id = Guid.NewGuid(),
                    DocumentId = documentId,
                    Tag = tag
                }).ToList();

                await _proDbContext.DocumentTags.AddRangeAsync(documentTags);
                await _proDbContext.SaveChangesAsync();
            }

            return ServiceResponse<bool>.SuccessResponse(true, "Tag(s) added successfully");
        }

        public async Task<ServiceResponse<bool>> RemoveTagsFromDocument(Guid documentId, string[] tags)
        {
            var document = await _proDbContext.Documents.FindAsync(documentId);
            if (document == null)
                return ServiceResponse<bool>.NotFoundErrorResponse("Document not found");

            var existingTags = await _proDbContext.DocumentTags
                .Where(dt => dt.DocumentId == documentId && tags.Contains(dt.Tag))
                .ToListAsync();

            if (existingTags.Any())
            {
                _proDbContext.DocumentTags.RemoveRange(existingTags);
                await _proDbContext.SaveChangesAsync();
            }

            return ServiceResponse<bool>.SuccessResponse(true, "Tag(s) removed successfully");
        }

        public async Task<ServiceResponse<List<DocumentMetadata>>> GetMetadataForCompany()
        {
            string currentCompanyId = AuthHelper.GetCurrentCompanyId();

            string metadataKey = $"company-{currentCompanyId}/metadata.json";

            var cachedMetadata = await _cacheService.GetAsync<List<DocumentMetadata>>(currentCompanyId);
            if (cachedMetadata != null)
            {
                return ServiceResponse<List<DocumentMetadata>>.SuccessResponse(cachedMetadata, "Metadata retrieved from cache successfully");
            }

            byte[] metadataData = await _s3Service.DownloadFileAsync(metadataKey);
            if (metadataData == null || metadataData.Length == 0)
                return ServiceResponse<List<DocumentMetadata>>.NotFoundErrorResponse("No metadata found for the company");

            string jsonString = Encoding.UTF8.GetString(metadataData);
            List<DocumentMetadata> metadataList = JsonSerializer.Deserialize<List<DocumentMetadata>>(jsonString) ?? new List<DocumentMetadata>();

            await _cacheService.SetAsync(currentCompanyId, metadataList, TimeSpan.FromHours(1));

            return ServiceResponse<List<DocumentMetadata>>.SuccessResponse(metadataList, "Metadata retrieved successfully");
        }

        public async Task<ServiceResponse<List<Document>>> SearchDocument(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return ServiceResponse<List<Document>>.ErrorResponse("Search query cannot be empty");

            string currentCompanyId = AuthHelper.GetCurrentCompanyId();
            string cacheKey = currentCompanyId;

            var metadataList = await _cacheService.GetAsync<List<DocumentMetadata>>(cacheKey);
            if (metadataList == null)
            {
                string metadataKey = $"company-{currentCompanyId}/metadata.json";
                byte[] metadataData = await _s3Service.DownloadFileAsync(metadataKey);
                if (metadataData == null || metadataData.Length == 0)
                    return ServiceResponse<List<Document>>.NotFoundErrorResponse("No metadata found for the company");

                string jsonString = Encoding.UTF8.GetString(metadataData);
                metadataList = JsonSerializer.Deserialize<List<DocumentMetadata>>(jsonString) ?? new List<DocumentMetadata>();

                await _cacheService.SetAsync(cacheKey, metadataList, TimeSpan.FromHours(1));
            }

            var matchingMetadata = metadataList.Where(m => m.FileName.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!matchingMetadata.Any())
                return ServiceResponse<List<Document>>.NotFoundErrorResponse("No matching documents found");

            var documentIds = matchingMetadata.Select(m => Guid.Parse(m.DocumentId)).ToList();

            var documents = await _proDbContext.Documents
                .Where(d => documentIds.Contains(d.Id))
                .ToListAsync();

            return ServiceResponse<List<Document>>.SuccessResponse(documents, "Documents retrieved successfully");
        }


        private async Task UpdateCompanyMetadata(string companyId, string userId, string documentId, string version, DateTime date, string fileName, string status)
        {
            string metadataKey = $"company-{companyId}/metadata.json";
            string cacheKey = $"{companyId}";
            List<DocumentMetadata> metadataList;

            try
            {
                var existingData = await _s3Service.DownloadFileAsync(metadataKey);
                var existingJson = Encoding.UTF8.GetString(existingData);
                metadataList = JsonSerializer.Deserialize<List<DocumentMetadata>>(existingJson) ?? new List<DocumentMetadata>();
            }
            catch
            {
                metadataList = new List<DocumentMetadata>();
            }

            var existingEntry = metadataList.FirstOrDefault(item => item.DocumentId == documentId);

            if (existingEntry != null)
            {
                existingEntry.Status = status;
                existingEntry.Date = date.ToString("yyyy-MM-dd");
            }
            else
            {
                metadataList.Add(new DocumentMetadata
                {
                    CompanyId = companyId,
                    UserId = userId,
                    DocumentId = documentId,
                    Version = version,
                    Date = date.ToString("yyyy-MM-dd"),
                    FileName = fileName,
                    Status = status
                });
            }

            string metadataJson = JsonSerializer.Serialize(metadataList, new JsonSerializerOptions { WriteIndented = true });

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(metadataJson)))
            {
                var formFile = new FormFile(stream, 0, stream.Length, "metadata", "metadata.json")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/json"
                };

                await _s3Service.UploadFileAsync(formFile, metadataKey);
            }

            await _cacheService.SetAsync(cacheKey, metadataList, TimeSpan.FromHours(1));
        }


        private async Task UpdateDocumentStatusInMetadata(string companyId, string documentId, string status)
        {
            string metadataKey = $"company-{companyId}/metadata.json";
            string cacheKey = $"{companyId}";

            byte[] metadataData = await _s3Service.DownloadFileAsync(metadataKey);
            if (metadataData?.Length == 0) return;

            string jsonString = Encoding.UTF8.GetString(metadataData);
            List<DocumentMetadata> metadataList = JsonSerializer.Deserialize<List<DocumentMetadata>>(jsonString) ?? new List<DocumentMetadata>();

            var existingEntry = metadataList.FirstOrDefault(item => item.DocumentId == documentId);

            if (existingEntry != null)
            {
                existingEntry.Status = status;
                existingEntry.Date = DateTime.UtcNow.ToString("yyyy-MM-dd");
            }

            string updatedJson = JsonSerializer.Serialize(metadataList, new JsonSerializerOptions { WriteIndented = true });

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(updatedJson)))
            {
                await _s3Service.UploadFileAsync(new FormFile(stream, 0, stream.Length, "metadata", "metadata.json")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/json"
                }, metadataKey);
            }

            await _cacheService.SetAsync(cacheKey, metadataList, TimeSpan.FromHours(1));
            
        }

    }
}
