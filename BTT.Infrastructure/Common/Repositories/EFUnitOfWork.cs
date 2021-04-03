using BTT.Domain.Common.Repository;
using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
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

        public IIssueRepository Issues { get; private set; }

        public IOrganizationRepository Organizations { get; private set; }

        public IMemberRepository Members { get; private set; }

        public IProjectRepository Projects { get; private set; }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }
    }
}