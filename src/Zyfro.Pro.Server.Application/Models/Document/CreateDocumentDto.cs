using System;

namespace Zyfro.Pro.Server.Application.Models.Document
{
    public class CreateDocumentDto
    {
        public Guid Id{ get; set; }
        public Guid OwnerId { get; set; }
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; } // PDF, DOCX, etc.
        public long FileSize { get; set; }
        public bool IsArchived { get; set; } = false;
    }
}
