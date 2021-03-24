using BTT.Domain.Common.Specification;
using System;
using System.Linq.Expressions;

namespace BTT.Domain.Models.Organizations
{
    public class OrganizationHasNameSpecification : BaseSpecification<Organization>
    {
        private string name;

        public OrganizationHasNameSpecification(string name) => this.name = name;

        public override Expression<Func<Organization, bool>> SpecExpression
        {
            get => organization => organization.Name == name;
        }
    }
}