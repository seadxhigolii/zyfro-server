using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Zyfro.Pro.Server.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public ICollection<Document> Documents { get; set; }
    }
}
