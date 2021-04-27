using AutoMapper;
using BTT.Application.Services.Issues;
using BTT.Application.Services.Members;
using BTT.Application.Services.Organizations;
using BTT.Application.Services.Projects;
using BTT.WebMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Models
{
    public class ModelsMapper : Profile
    {
        public ModelsMapper()
        {
            CreateMap<IssueDto, IssueViewModel>();
            CreateMap<MemberDto, MemberViewModel>();
            CreateMap<ProjectDto, ProjectViewModel>();
            CreateMap<OrganizationDto, OrganizationViewModel>();
            CreateMap<AttachmentDto, AttachmentViewModel>();
            CreateMap<CommentDto, CommentViewModel>();
        }
    }
}
