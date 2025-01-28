using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyfro.Pro.Server.Domain.Entities.Base;

namespace Zyfro.Pro.Server.Domain.Entities
{
    public class SignatureRequest : BaseEntity<Guid>
    {
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }

        public Guid RequestedById { get; set; }
        public ApplicationUser RequestedBy { get; set; }

        public Guid RequestedToId { get; set; }
        public ApplicationUser RequestedTo { get; set; }

        public bool IsSigned { get; set; } = false;
        public DateTime? SignedAt { get; set; }
    }

}
