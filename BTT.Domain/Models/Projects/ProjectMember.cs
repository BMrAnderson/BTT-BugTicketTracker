using BTT.Domain.Common.Validation;
using BTT.Domain.Models.Members;
using System;

namespace BTT.Domain.Models.Projects
{
    public class ProjectMember 
    {
        public ProjectMember(Project project, Member member)
        {
            Validate(project, member);

            this.Project = project;
            this.Member = member;
            this.ProjectId = project.Id;
            this.MemberId = member.Id;
        }

        public Guid ProjectId { get; private set; }

        public Project Project { get; private set; }

        public Guid MemberId { get; private set; }

        public Member Member { get; private set; }

        private void Validate(Project project, Member member)
        {
            Validation.CheckNull(project, nameof(project));
            Validation.CheckNull(member, nameof(member));
        }
    }
}