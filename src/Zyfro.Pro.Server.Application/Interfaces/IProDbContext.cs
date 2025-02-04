using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Zyfro.Pro.Server.Domain.Entities;

namespace Zyfro.Pro.Server.Application.Interfaces
{
    public interface IProDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<AuditLog> AuditLogs { get; set; }
        DbSet<DocumentTag> DocumentTags { get; set; }
        DbSet<DocumentVersion> DocumentVersions { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<SignatureRequest> SignatureRequests { get; set; }
        DbSet<Workflow> Workflows { get; set; }
        DbSet<WorkflowStep> WorkflowSteps { get; set; }
    }
}
