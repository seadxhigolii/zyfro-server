using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Common.Helpers;
using Zyfro.Pro.Server.Common.Response;
using Zyfro.Pro.Server.Domain.Entities;

namespace Zyfro.Pro.Server.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IProDbContext _proDbContext;
        public DocumentService(IProDbContext proDbContext)
        {
            _proDbContext = proDbContext;
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
        public async Task<ServiceResponse<bool>> CreateDocument(Document model)
        {
            Guid currentUserId = Guid.Parse(AuthHelper.GetCurrentUserId());
            return ServiceResponse<bool>.SuccessResponse(false, "Document Upload Failed", 500);
        }
    }
}
