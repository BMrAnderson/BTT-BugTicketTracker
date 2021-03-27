using BTT.Application.Services.Members;
using BTT.Application.Services.Projects;
using System;
using System.Collections.Generic;

namespace BTT.Application.Services.Organizations
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public List<MemberDto> Members { get; set; }
    }
}