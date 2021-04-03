using BTT.Domain.Common.Repository;
using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Organizations;
using BTT.Infrastructure.Common.Persistence;
using BTT.Infrastructure.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTT.Infrastructure.Common.Repositories
{
    public class OrganizationRepository : EFRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(IssueTicketTrackerDBContext context) : base(context)
        {

        }

        public Organization GetOrganizationByName(string name)
        {
            return _entities.Where(o => o.Name == name).FirstOrDefault();
        }
    }
}