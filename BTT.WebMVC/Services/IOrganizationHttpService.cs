using BTT.WebMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public interface IOrganizationHttpService
    {
        OrganizationViewModel Get(Guid organzationId);
        OrganizationViewModel Add(string organizationName);
        ProjectViewModel Add(Guid organizationId, ProjectViewModel projectVM);
        MemberViewModel Add(Guid organizationId, MemberViewModel memberVM);
        void Remove(Guid organizationId);
    }
}
