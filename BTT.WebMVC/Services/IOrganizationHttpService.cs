using BTT.WebMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public interface IOrganizationHttpService
    {
        Task<OrganizationViewModel> Get(Guid organzationId);
        Task<bool> Add(string organizationName);
        Task<bool> Add(Guid organizationId, ProjectViewModel projectVM);
        Task<bool> Add(Guid organizationId, MemberViewModel memberVM);
        Task<bool> Remove(Guid organizationId);
    }
}
