using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BTT.Infrastructure.Common.Persistence
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}