using BTT.Domain.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Issues
{
    public class IssueAfterDueDateSpecification : BaseSpecification<Issue>
    {
        readonly DateTimeOffset dueDate;

        public IssueAfterDueDateSpecification(DateTimeOffset dueDate) => this.dueDate = dueDate;

        public override Expression<Func<Issue, bool>> SpecExpression
        {
            get => issue => issue.DueDate >= dueDate;
        }
    }
}
