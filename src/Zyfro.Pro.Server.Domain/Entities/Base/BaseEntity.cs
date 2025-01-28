using System;

namespace Zyfro.Pro.Server.Domain.Entities.Base
{
    public class BaseEntity<TKey> : EntityTimeStamp where TKey : IEquatable<TKey>
    {
        public Guid Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime LastUpdatedAtUtc { get; set; }
        public DateTime? DeletedAtUtc { get; set; }
    }
}
