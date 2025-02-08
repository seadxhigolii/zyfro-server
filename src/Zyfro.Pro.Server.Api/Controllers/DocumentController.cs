using Microsoft.AspNetCore.Mvc;
using Zyfro.Pro.Server.Domain.Entities;
using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Api.Controllers.Base;

namespace Zyfro.Pro.Server.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : BaseController
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDocuments()
        {
            var response = await _documentService.GetAllDocuments();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentById(Guid id)
        {
            var response = await _documentService.GetDocumentById(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocument(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var response = await _documentService.CreateDocument(file);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(Guid id, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var response = await _documentService.UpdateDocument(id,file);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(Guid id)
        {
            var response = await _documentService.SoftDeleteDocument(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{id}/archive")]
        public async Task<IActionResult> ArchiveDocument(Guid id)
        {
            var response = await _documentService.ArchiveDocument(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{id}/unarchive")]
        public async Task<IActionResult> UnarchiveDocument(Guid id)
        {
            var response = await _documentService.UnarchiveDocument(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{id}/tags")]
        public async Task<IActionResult> AddTagsToDocument(Guid id, string[] tags)
        {
            var response = await _documentService.AddTagsToDocument(id,tags);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{documentId}/tags")]
        public async Task<IActionResult> RemoveTagsFromDocument(Guid documentId, string[] tags)
        {
            var response = await _documentService.RemoveTagsFromDocument(documentId, tags);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetMetadata")]
        public async Task<IActionResult> GetMetadata()
        {
            var response = await _documentService.GetMetadataForCompany();

            return StatusCode(response.StatusCode, response);
        }

        // GET: api/documents/search?ownerId={ownerId}&tag={tag}&dateFrom={dateFrom}&dateTo={dateTo}
        [HttpGet("search")]
        public async Task<IActionResult> SearchDocuments(Guid? ownerId, string tag, DateTime? dateFrom, DateTime? dateTo)
        {
            return Ok();
        }
    }
}
