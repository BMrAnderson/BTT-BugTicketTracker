using BTT.Domain.Common.Specification;
using System;
using System.Linq.Expressions;

namespace BTT.Domain.Models.Issues
{
    public class IssueReachedDueDateSpecification : BaseSpecification<Issue>
    {
        private readonly DateTime dueDate;

        public IssueReachedDueDateSpecification(DateTime dueDate) => this.dueDate = dueDate;

        public override Expression<Func<Issue, bool>> SpecExpression
        {
            get => issue => issue.EndDueDate >= dueDate;
        }
    }
}