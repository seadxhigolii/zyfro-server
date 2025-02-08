using System;
using Zyfro.Pro.Server.Domain.Entities.Base;

namespace Zyfro.Pro.Server.Domain.Entities
{
    public class Notification : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
    }

}
