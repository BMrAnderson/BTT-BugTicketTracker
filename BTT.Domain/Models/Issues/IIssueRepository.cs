using BTT.Domain.Common.Repository;
using System;
using System.Collections.Generic;

namespace BTT.Domain.Models.Issues
{
    public interface IIssueRepository : IRepository<Issue>
    {
        IEnumerable<Issue> GetIssuesByProjectId(Guid id);
    }
}