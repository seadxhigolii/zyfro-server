using System;
using System.Collections;
using System.Collections.Generic;
using Zyfro.Pro.Server.Domain.Entities.Base;

namespace Zyfro.Pro.Server.Domain.Entities
{
    public class ApplicationUser : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Document> Documents { get; set; }
    }
}
