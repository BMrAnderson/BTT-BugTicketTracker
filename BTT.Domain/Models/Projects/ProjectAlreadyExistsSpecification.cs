using BTT.Domain.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Projects
{
    public class ProjectAlreadyExistsSpecification : BaseSpecification<Project>
    {
        private Guid _projectId;
        private string _title;

        public ProjectAlreadyExistsSpecification(Guid projectId, string title)
        {
            this._projectId = projectId;
            this._title = title;
        }

        public override Expression<Func<Project, bool>> SpecExpression
        {
            get => project => project.Title == _title || project.Id == _projectId; 
        }
    }
}
