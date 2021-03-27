using BTT.Domain.Common.Events;
using BTT.Domain.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Organizations
{
    public class OrganizationExistsByNameSpecification : BaseSpecification<Organization>
    {
        private string _organizationName;

        public OrganizationExistsByNameSpecification(string organizationName)
        {
            this._organizationName = organizationName;
        }

        public override Expression<Func<Organization, bool>> SpecExpression
        {
            get => organization => organization.Name == _organizationName;
        }
    }
}
