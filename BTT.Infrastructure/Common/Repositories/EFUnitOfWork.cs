using BTT.Domain.Common.Repository;
using BTT.Infrastructure.Common.Persistence;
using System.Threading.Tasks;

namespace BTT.Infrastructure.Common.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly IssueTicketTrackerDBContext _context;

        public EFUnitOfWork(IssueTicketTrackerDBContext context)
        {
            _context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
    }
}