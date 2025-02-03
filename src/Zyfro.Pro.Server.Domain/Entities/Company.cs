using System;
using System.Collections;
using System.Collections.Generic;
using Zyfro.Pro.Server.Domain.Entities.Base;

namespace Zyfro.Pro.Server.Domain.Entities
{
    public class Company : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public Company()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
