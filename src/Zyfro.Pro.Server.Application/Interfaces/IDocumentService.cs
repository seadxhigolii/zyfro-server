using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zyfro.Pro.Server.Common.Response;
using Zyfro.Pro.Server.Domain.Entities;

namespace Zyfro.Pro.Server.Application.Interfaces
{
    public interface IDocumentService
    {
        Task<ServiceResponse<List<Document>>> GetAllDocuments();
        Task<ServiceResponse<Document>> GetDocumentById(Guid id);
        Task<ServiceResponse<bool>> CreateDocument(IFormFile file);
        Task<ServiceResponse<bool>> ArchiveDocument(Guid id);
        Task<ServiceResponse<bool>> SoftDeleteDocument(Guid id);
        Task<ServiceResponse<bool>> UpdateDocument(Guid id, IFormFile file);
    }
}
