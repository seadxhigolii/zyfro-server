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
    public class WorkflowConfiguration : IEntityTypeConfiguration<Workflow>
    {
        public void Configure(EntityTypeBuilder<Workflow> builder)
        {
            builder.UseBaseConfigurations<Workflow, Guid>();

            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(x => x.Document)
                .WithMany(x => x.Workflows)
                .HasForeignKey(x => x.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
