using BTT.WebMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public class ProjectHttpService : IProjectHttpService
    {
        public ProjectViewModel Add(ProjectViewModel projectVM)
        {
            throw new NotImplementedException();
        }

        public MemberViewModel Add(Guid projectId, MemberViewModel memberVM)
        {
            throw new NotImplementedException();
        }

        public IssueViewModel Add(Guid memberId, Guid projectId, IssueViewModel issueVM)
        {
            throw new NotImplementedException();
        }

        public void Edit(ProjectViewModel projectVM)
        {
            throw new NotImplementedException();
        }

        public ProjectViewModel Get(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid projectId)
        {
            throw new NotImplementedException();
        }
    }
}
