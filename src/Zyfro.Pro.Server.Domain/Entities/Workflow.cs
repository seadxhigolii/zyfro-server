using System;
using System.Collections.Generic;
using Zyfro.Pro.Server.Domain.Entities.Base;

namespace Zyfro.Pro.Server.Domain.Entities
{
    public class Workflow : BaseEntity<Guid>
    {
        public string Name { get; set; } // e.g., "Contract Approval"
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<WorkflowStep> Steps { get; set; }
    }

}
