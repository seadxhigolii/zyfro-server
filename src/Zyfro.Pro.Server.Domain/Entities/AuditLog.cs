using System;
using Zyfro.Pro.Server.Domain.Entities.Base;

namespace Zyfro.Pro.Server.Domain.Entities
{
    public class AuditLog : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Action { get; set; } // "Document Uploaded", "Workflow Approved"
        public Guid? DocumentId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

}
