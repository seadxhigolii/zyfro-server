using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyfro.Pro.Server.Domain.Entities.Base;

namespace Zyfro.Pro.Server.Domain.Entities
{
    public class DocumentVersion : BaseEntity<Guid>
    {
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }

        public int VersionNumber { get; set; }
        public string FilePath { get; set; } // Storage path of this version
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
