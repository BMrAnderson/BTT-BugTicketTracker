using BTT.Domain.Common.Repository;
using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Issues;
using BTT.Infrastructure.Common.Persistence;
using BTT.Infrastructure.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTT.Infrastructure.Common.Repositories
{
    public class IssueRepository : EFRepository<Issue>, IIssueRepository
    {
        public IssueRepository(IssueTicketTrackerDBContext context) : base(context)
        {

        }

        public IEnumerable<Issue> GetIssuesByPriority(Priority priority)
        {
            return this._entities.Where(i => i.Priority == priority);
        }
    }
}