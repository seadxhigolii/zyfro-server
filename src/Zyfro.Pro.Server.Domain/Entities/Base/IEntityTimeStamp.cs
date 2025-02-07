using System;

namespace Zyfro.Pro.Server.Domain.Entities.Base
{
    public interface IEntityTimeStamp
    {
        DateTime CreatedAtUtc { get; set; }
        DateTime UpdatedAtUtc { get; set; }
        DateTime? DeletedAtUtc { get; set; }
    }
}