using Microsoft.EntityFrameworkCore;

namespace Zyfro.Pro.Server.Domain.Enums
{
    public enum EntityStatus
    {
        Created,
        Modified,
        Archived,
        Deleted,
        Active,
        Inactive,
    }
}
