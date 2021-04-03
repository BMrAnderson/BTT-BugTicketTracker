using BTT.WebMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public interface IProjectHttpService
    {
        ProjectViewModel Get(Guid projectId);
        ProjectViewModel Add(ProjectViewModel projectVM);
        void Remove(Guid projectId);
        void Edit(ProjectViewModel projectVM);
        MemberViewModel Add(Guid projectId, MemberViewModel memberVM);
        IssueViewModel Add(Guid memberId, Guid projectId, IssueViewModel issueVM);
    }
}
