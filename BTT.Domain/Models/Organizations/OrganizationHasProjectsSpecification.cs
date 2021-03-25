using BTT.Domain.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Organizations
{
    public class OrganizationHasProjectsSpecification : BaseSpecification<Organization>
    {
        public override Expression<Func<Organization, bool>> SpecExpression
        {
            get => organization => organization.Projects.Count != 0;
        }
    }
}
