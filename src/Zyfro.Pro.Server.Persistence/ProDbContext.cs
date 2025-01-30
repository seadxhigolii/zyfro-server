using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Domain.Entities;
using Zyfro.Pro.Server.Domain.Entities.Base;
using Zyfro.Pro.Server.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Zyfro.Pro.Server.Persistence
{
    public class ProDbContext : DbContext, IProDbContext
    {
        public ProDbContext(DbContextOptions<ProDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<DocumentTag> DocumentTags { get; set; }
        public DbSet<DocumentVersion> DocumentVersions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<SignatureRequest> SignatureRequests { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<WorkflowStep> WorkflowSteps { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries()
                         .Where(x => typeof(IEntityTimeStamp).IsAssignableFrom(x.Entity.GetType()) && x.State == EntityState.Modified)
                         .ToList()
                         .ForEach(x =>
                         {
                             x.Property(nameof(IEntityTimeStamp.UpdatedAt)).CurrentValue = DateTime.UtcNow;
                         });

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var type = entityType.ClrType;

                if (type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntity<>))
                {
                    var entityBuilder = typeof(ModelBuilder)
                        .GetMethod(nameof(ModelBuilder.Entity), Type.EmptyTypes)!
                        .MakeGenericMethod(type)
                        .Invoke(modelBuilder, null);

                    var method = type.BaseType
                        .GetMethod(nameof(BaseEntityConfiguration.UseBaseConfigurations))
                        ?.MakeGenericMethod(type, type.BaseType.GenericTypeArguments[0]);

                    method?.Invoke(null, new object[] { entityBuilder });
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}