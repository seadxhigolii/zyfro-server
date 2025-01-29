using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Common.Extensions;
using Zyfro.Pro.Server.Domain.Entities;
using Zyfro.Pro.Server.Domain.Entities.Base;
using Zyfro.Pro.Server.Persistence.Configurations.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Zyfro.Pro.Server.Persistence
{
    public class ProDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>, IProDbContext
    {
        public ProDbContext(DbContextOptions<ProDbContext> options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries()
                         .Where(x => typeof(IEntityTimeStamp).IsAssignableFrom(x.Entity.GetType()) && x.State == EntityState.Modified)
                         .Select(x => x.Entity)
                         .ForEach((x) =>
                         {
                             x.GetType().GetProperty(nameof(IEntityTimeStamp.UpdatedAt))?.SetValue(x, DateTime.UtcNow);
                         });

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var type = entityType.ClrType;

                if (type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntity<>))
                {
                    var entityBuilder = typeof(ModelBuilder)
                        .GetMethod(nameof(ModelBuilder.Entity), new Type[] { })!
                        .MakeGenericMethod(type)
                        .Invoke(modelBuilder, null);

                    var method = typeof(BaseEntityConfiguration)
                        .GetMethod(nameof(BaseEntityConfiguration.UseBaseConfigurations))
                        ?.MakeGenericMethod(type, type.BaseType.GenericTypeArguments[0]);

                    method?.Invoke(null, new object[] { entityBuilder });
                }

                if (entityType.GetTableName() is string table && table.StartsWith("AspNet"))
                    entityType.SetTableName(table[6..]);
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
