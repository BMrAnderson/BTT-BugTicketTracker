using BTT.Domain.Common.Repository;
using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Members;
using BTT.Infrastructure.Common.Persistence;
using BTT.Infrastructure.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTT.Infrastructure.Common.Repositories
{
    public class MemberRepository : EFRepository<Member>, IMemberRepository
    {
        public MemberRepository(IssueTicketTrackerDBContext context): base(context)
        {

        }

        public IEnumerable<Member> GetMembersByOrganizationId(Guid organizationId)
        {
            return _entities.Where(m => m.OrganizationId == organizationId);
        }
    }
}