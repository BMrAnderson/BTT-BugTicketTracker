using BTT.Application.Services.Projects;
using System;
using System.Collections.Generic;

namespace BTT.Application.Services.Members
{
    public interface IMemberService
    {
        bool EmailExists(string email);
        void Remove(Guid memberId);
        void Edit(MemberDto memberDto);
        MemberDto Get(Guid memberId);
        MemberDto Add(MemberDto memberDto);
        ProjectDto Add(Guid memberId, ProjectDto projectDto);
    }
}