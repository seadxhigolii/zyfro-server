using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyfro.Pro.Server.Domain.Entities;
using Zyfro.Pro.Server.Persistence.Configurations.Base;

namespace Zyfro.Pro.Server.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.UseBaseConfigurations<Company, Guid>();

            builder.Property(x => x.Address)
                .IsRequired();

            builder.Property(x => x.)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.FailedLoginAttempts)
                .IsRequired();

            builder.Property(x => x.LockoutEndTime)
                .IsRequired(false);

            builder.Property(x => x.PasswordHash)
                .HasMaxLength(512)
                .IsRequired();

            builder.HasMany(x => x.Documents)
                .WithOne(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
