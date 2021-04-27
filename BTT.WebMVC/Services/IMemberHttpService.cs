using BTT.WebMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public interface IMemberHttpService
    {
        Task<bool> EmailExists(string email);
        Task<bool> Remove(Guid memberId);
        Task<bool> Edit(MemberViewModel memberVM);
        Task<MemberViewModel> Get(Guid memberId);
        Task<bool> Add(MemberViewModel memberVM);
        Task<bool> Add(Guid memberId, ProjectViewModel projectVM);
    }
}
