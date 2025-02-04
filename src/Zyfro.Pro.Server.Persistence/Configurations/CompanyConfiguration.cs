using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Zyfro.Pro.Server.Domain.Entities;
using Zyfro.Pro.Server.Persistence.Configurations.Base;

namespace Zyfro.Pro.Server.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.UseBaseConfigurations<Company, Guid>();

            builder.Property(x => x.Name)
                .IsRequired();


            builder.HasMany(c => c.ApplicationUsers)
                .WithOne(u => u.Company)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Documents)
                .WithOne(d => d.Company)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
