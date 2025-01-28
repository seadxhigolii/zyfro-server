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
    public class SignatureRequestConfiguration : IEntityTypeConfiguration<SignatureRequest>
    {
        public void Configure(EntityTypeBuilder<SignatureRequest> builder)
        {
            builder.UseBaseConfigurations<SignatureRequest, Guid>();

            builder.HasOne(x => x.Document)
                .WithMany()
                .HasForeignKey(x => x.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.RequestedBy)
                .WithMany()
                .HasForeignKey(x => x.RequestedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RequestedTo)
                .WithMany()
                .HasForeignKey(x => x.RequestedToId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
