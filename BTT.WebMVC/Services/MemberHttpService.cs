using BTT.WebMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public class MemberHttpService : IMemberHttpService
    {
        public MemberViewModel Add(MemberViewModel memberVM)
        {
            throw new NotImplementedException();
        }

        public ProjectViewModel Add(Guid memberId, ProjectViewModel projectVM)
        {
            throw new NotImplementedException();
        }

        public void Edit(MemberViewModel memberVM)
        {
            throw new NotImplementedException();
        }

        public bool EmailExists(string email)
        {
            throw new NotImplementedException();
        }

        public MemberViewModel Get(Guid memberId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid memberId)
        {
            throw new NotImplementedException();
        }
    }
}
