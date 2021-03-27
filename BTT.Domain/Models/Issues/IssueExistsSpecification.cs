using BTT.Domain.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Issues
{
    public class IssueExistsSpecification : BaseSpecification<Issue>
    {
        private readonly Guid _issueId;

        public IssueExistsSpecification(Guid issueId)
        {
            _issueId = issueId;
        }

        public override Expression<Func<Issue, bool>> SpecExpression
        {
            get => issue => issue.Id == _issueId;
        }
    }
}
