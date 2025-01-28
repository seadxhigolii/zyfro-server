using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Zyfro.Pro.Server.Application.Interfaces
{
    public interface IProDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
