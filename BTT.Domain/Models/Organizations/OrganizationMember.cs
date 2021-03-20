using BTT.Domain.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Organizations
{
    public class OrganizationMember 
    {
        public Guid OrganizationId { get;  }

        public Guid MemberId { get; }

        public OrganizationMember(Organization organization, Member member)
        {
            this.OrganizationId = organization.Id;
            this.MemberId = member.Id;
        }
    }
}
