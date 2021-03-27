using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Projects;
using System;
using System.Linq.Expressions;

namespace BTT.Domain.Models.Issues
{
    public class IssueExistsInProjectSpecification : BaseSpecification<Issue>
    {
        private readonly Guid _projectId;

        public IssueExistsInProjectSpecification(Guid projectId) => this._projectId = projectId;

        public override Expression<Func<Issue, bool>> SpecExpression
        {
            get => issue => issue.ProjectId == this._projectId;
        }
    }
}