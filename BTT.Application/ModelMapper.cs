using AutoMapper;
using BTT.Application.Services.Issues;
using BTT.Application.Services.Members;
using BTT.Application.Services.Organizations;
using BTT.Application.Services.Projects;
using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoMapper.Internal.ExpressionFactory;

namespace BTT.Application
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<Issue, IssueDto>()
                .ReverseMap();

            CreateMap<Member, MemberDto>()
                .ReverseMap();

            CreateMap<Organization, OrganizationDto>()
                .ReverseMap();

            CreateMap<Project, ProjectDto>()
                .ReverseMap();

            CreateMap<Attachment, AttachmentDto>()
                .ReverseMap();

            CreateMap<Comment, CommentDto>()
                .ReverseMap();
        }
    }
}
