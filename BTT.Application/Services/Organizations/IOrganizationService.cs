using BTT.Application.Services.Members;
using BTT.Application.Services.Projects;
using System;

namespace BTT.Application.Services.Organizations
{
    public interface IOrganizationService
    {
        OrganizationDto Get(Guid organzationId);
        OrganizationDto Add(string organizationName);
        ProjectDto Add(Guid organizationId, ProjectDto projectDto);
        MemberDto Add(Guid organizationId, MemberDto memberDto);
        void Remove(Guid organizationId);
    }
}