using BTT.Domain.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Issues
{
    public class IssueByPrioritySpecification : BaseSpecification<Issue>
    {
        private Priority _priority;

        public IssueByPrioritySpecification(Priority priority)
        {
            this._priority = priority;
        }

        public override Expression<Func<Issue, bool>> SpecExpression
        {
            get => issue => issue.Priority == _priority;
        }
    }
}
