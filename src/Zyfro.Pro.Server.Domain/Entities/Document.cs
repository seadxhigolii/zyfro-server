using System;
using System.Collections.Generic;
using Zyfro.Pro.Server.Domain.Entities.Base;

namespace Zyfro.Pro.Server.Domain.Entities
{
    public class Document : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string FilePath { get; set; } // Cloud Storage URL
        public string ContentType { get; set; } // PDF, DOCX, etc.
        public long FileSize { get; set; }
        public bool IsArchived { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Key - User who uploaded the document
        public Guid OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        // Relationships
        public ICollection<DocumentVersion> Versions { get; set; }
        public ICollection<DocumentTag> Tags { get; set; }
        public ICollection<Workflow> Workflows { get; set; }
    }

}
