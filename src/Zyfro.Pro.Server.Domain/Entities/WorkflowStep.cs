using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyfro.Pro.Server.Domain.Entities.Base;

namespace Zyfro.Pro.Server.Domain.Entities
{
    public class WorkflowStep : BaseEntity<Guid>
    {
        public Guid WorkflowId { get; set; }
        public Workflow Workflow { get; set; }

        public string Name { get; set; } // e.g., "Manager Approval"
        public int StepNumber { get; set; }

        public Guid? AssignedToUserId { get; set; }
        public ApplicationUser? AssignedToUser { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Completed
        public DateTime? CompletedAt { get; set; }
    }

}
