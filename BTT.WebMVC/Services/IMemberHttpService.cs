using BTT.WebMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public interface IMemberHttpService
    {
        bool EmailExists(string email);
        void Remove(Guid memberId);
        void Edit(MemberViewModel memberVM);
        MemberViewModel Get(Guid memberId);
        MemberViewModel Add(MemberViewModel memberVM);
        ProjectViewModel Add(Guid memberId, ProjectViewModel projectVM);
    }
}
