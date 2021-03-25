using BTT.Domain.Common.Extensions;
using BTT.Domain.Models.Members;
using System;

namespace BTT.Domain.Models.Projects
{
    public class ProjectMember
    {
        public ProjectMember(Project project, Member member)
        {
            project.CheckNull(nameof(project));
            member.CheckNull(nameof(member));

            this.Project = project;
            this.Member = member;
            this.ProjectId = project.Id;
            this.MemberId = member.Id;
        }

        public Guid ProjectId { get; private set; }

        public Project Project { get; private set; }

        public Guid MemberId { get; private set; }

        public Member Member { get; private set; }
    }
}