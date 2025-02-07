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
            var response = await _documentService.GetAllDocuments();

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

            if (response.Success)
            {
                return Ok(new { Message = response.Message, Data = response.Data });
            }
            else
            {
                return StatusCode(response.StatusCode, new { Message = response.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(Guid id, [FromBody] Document updatedDocument)
        {
            return NoContent();
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
            var response = await _documentService.SoftDeleteDocument(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{id}/unarchive")]
        public async Task<IActionResult> UnarchiveDocument(Guid id)
        {
            return NoContent();
        }

        [HttpPost("{id}/tags")]
        public async Task<IActionResult> AddTagToDocument(Guid id, [FromBody] DocumentTag tag)
        {
            return Ok();
        }

        [HttpDelete("{id}/tags/{tagId}")]
        public async Task<IActionResult> RemoveTagFromDocument(Guid id, Guid tagId)
        {
            return NoContent();
        }

        // GET: api/documents/search?ownerId={ownerId}&tag={tag}&dateFrom={dateFrom}&dateTo={dateTo}
        [HttpGet("search")]
        public async Task<IActionResult> SearchDocuments(Guid? ownerId, string tag, DateTime? dateFrom, DateTime? dateTo)
        {
            return Ok();
        }
    }
}
