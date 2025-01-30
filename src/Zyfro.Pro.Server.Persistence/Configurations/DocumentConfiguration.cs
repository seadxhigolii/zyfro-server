using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Zyfro.Pro.Server.Domain.Entities;
using Zyfro.Pro.Server.Persistence.Configurations.Base;

namespace Zyfro.Pro.Server.Persistence.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.UseBaseConfigurations<Document, Guid>();

            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.FilePath)
                .IsRequired();

            builder.Property(x => x.ContentType)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.Owner)
                .WithMany(x => x.Documents)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
