using BTT.Domain.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Issues
{
    public class IssueAlreadyExistsSpecification : BaseSpecification<Issue>
    {
        private Issue _issue;

        public IssueAlreadyExistsSpecification(Issue issue)
        {
            this._issue = issue;
        }

        public override Expression<Func<Issue, bool>> SpecExpression
        {
            get => issue =>
            (
                issue.Title == _issue.Title &&
                issue.Description == _issue.Description &&
                issue.Priority == _issue.Priority &&
                issue.ProjectId == _issue.ProjectId
            );
        }
    }
}
