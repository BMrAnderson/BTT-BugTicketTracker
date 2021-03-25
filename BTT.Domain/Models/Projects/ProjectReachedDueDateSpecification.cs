using BTT.Domain.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Projects
{
    public class ProjectReachedDueDateSpecification : BaseSpecification<Project>
    {
        private DateTime _dueDate;

        public ProjectReachedDueDateSpecification(DateTime dueDate)
        {
            this._dueDate = dueDate;
        }

        public override Expression<Func<Project, bool>> SpecExpression
        {
            get => project => project.EndDueDate >= _dueDate;
        }
    }
}
