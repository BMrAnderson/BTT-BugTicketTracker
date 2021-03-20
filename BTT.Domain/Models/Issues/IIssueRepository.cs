using BTT.Domain.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Issues
{
    public interface IIssueRepository : IRepository<Issue>
    {
        IEnumerable<Issue> GetIssuesByProjectId(Guid id);
    }
}
