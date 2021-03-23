using BTT.Domain.Models.Members;
using System;

namespace BTT.Domain.Models.Projects
{
    public class ProjectMember
    {
        public Guid ProjectId { get; private set; }

        public Project Project { get; private set; }

        public Guid MemberId { get; private set; }

        public Member Member { get; private set; }
    }
}