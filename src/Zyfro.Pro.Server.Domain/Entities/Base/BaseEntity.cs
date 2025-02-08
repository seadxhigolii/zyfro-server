using System;
using Zyfro.Pro.Server.Domain.Enums;

namespace Zyfro.Pro.Server.Domain.Entities.Base
{
    public class BaseEntity<TKey> : EntityTimeStamp where TKey : IEquatable<TKey>
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public string CurrentStateUser { get; set; }
        public EntityStatus CurrentStatus { get; set; } = EntityStatus.Created;
    }
}
