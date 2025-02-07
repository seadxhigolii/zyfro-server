using System;

namespace Zyfro.Pro.Server.Domain.Entities.Base
{
    public class EntityTimeStamp : IEntityTimeStamp
    {
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAtUtc { get; set; }
    }
}
