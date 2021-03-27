using BTT.Domain.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Organizations
{
    public class OrganizationExistsSpecification : BaseSpecification<Organization>
    {
        private readonly Guid _organizationId;

        public OrganizationExistsSpecification(Guid organizationId)
        {
            this._organizationId = organizationId;
        }

        public override Expression<Func<Organization, bool>> SpecExpression
        {
            get => organization => organization.Id == _organizationId;
        }
    }
}
