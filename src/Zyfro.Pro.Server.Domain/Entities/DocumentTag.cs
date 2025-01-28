using System;
using Zyfro.Pro.Server.Domain.Entities.Base;

namespace Zyfro.Pro.Server.Domain.Entities
{
    public class DocumentTag : BaseEntity<Guid>
    {
        public string Tag { get; set; } // e.g., "Contract", "Invoice"
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
