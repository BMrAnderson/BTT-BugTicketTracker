using BTT.Domain.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Projects
{
    public class ProjectMember
    {
        public Guid ProjectId { get; }

        public Guid MemberId { get; }

        public ProjectMember(Project project, Member member)
        {
            this.ProjectId = project.Id;
            this.MemberId = member.Id;
        }
    }
}
