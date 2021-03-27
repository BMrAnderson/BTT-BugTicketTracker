using BTT.Application.Services.Issues;
using BTT.Application.Services.Members;
using System;

namespace BTT.Application.Services.Projects
{
    public interface IProjectService
    {
        ProjectDto Get(Guid projectId);
        ProjectDto Add(ProjectDto projectDto);
        void Remove(Guid projectId);
        void Edit(ProjectDto projectDto);
        MemberDto Add(Guid projectId, MemberDto memberDto);
        IssueDto Add(Guid memberId, Guid projectId, IssueDto issueDto);
    }
}