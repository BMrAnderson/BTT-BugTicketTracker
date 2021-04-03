using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Projects
{
    public class ProjectHasMembersSpecification : BaseSpecification<Project>
    {
        private readonly Guid _projectId;

        public ProjectHasMembersSpecification(Guid projectId)
        {
            this._projectId = projectId;
        }

        public override Expression<Func<Project, bool>> SpecExpression
        {
            get => project => project.ProjectMembers.All(pm => pm.ProjectId == _projectId);
        }
    }
}
