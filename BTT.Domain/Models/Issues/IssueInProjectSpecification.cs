using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Projects;
using System;
using System.Linq.Expressions;

namespace BTT.Domain.Models.Issues
{
    public class IssueInProjectSpecification : BaseSpecification<Issue>
    {
        private readonly Project project;

        public IssueInProjectSpecification(Project project) => this.project = project;

        public override Expression<Func<Issue, bool>> SpecExpression
        {
            get => issue => issue.ProjectId == this.project.Id;
        }
    }
}