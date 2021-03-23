using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Issues
{
    public class IssueInProjectSpecification : BaseSpecification<Issue>
    {
        readonly Project project;

        public IssueInProjectSpecification(Project project) => this.project = project;

        public override Expression<Func<Issue, bool>> SpecExpression
        {
            get => issue => issue.ProjectId == this.project.Id;
        }
           
    }
}
