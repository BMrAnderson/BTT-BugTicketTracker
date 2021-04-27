using BTT.WebMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public interface IProjectHttpService
    {
        Task<ProjectViewModel> Get(Guid projectId);
        Task<bool> Add(ProjectViewModel projectVM);
        Task<bool> Remove(Guid projectId);
        Task<bool> Edit(ProjectViewModel projectVM);
        Task<bool> Add(Guid projectId, MemberViewModel memberVM);
        Task<bool> Add(Guid memberId, Guid projectId, IssueViewModel issueVM);
    }
}
