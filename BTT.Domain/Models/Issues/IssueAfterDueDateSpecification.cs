using BTT.Domain.Common.Specification;
using System;
using System.Linq.Expressions;

namespace BTT.Domain.Models.Issues
{
    public class IssueAfterDueDateSpecification : BaseSpecification<Issue>
    {
        private readonly DateTime dueDate;

        public IssueAfterDueDateSpecification(DateTime dueDate) => this.dueDate = dueDate;

        public override Expression<Func<Issue, bool>> SpecExpression
        {
            get => issue => issue.EndDueDate >= dueDate;
        }
    }
}