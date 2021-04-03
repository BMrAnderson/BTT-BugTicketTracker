using BTT.Domain.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Members
{
    public interface IMemberRepository : IRepository<Member>
    {
        IEnumerable<Member> GetMembersByOrganizationId(Guid organizationId);
    }
}
