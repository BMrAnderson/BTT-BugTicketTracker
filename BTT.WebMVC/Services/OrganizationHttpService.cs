using BTT.WebMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public class OrganizationHttpService : IOrganizationHttpService
    {
        public OrganizationViewModel Add(string organizationName)
        {
            throw new NotImplementedException();
        }

        public ProjectViewModel Add(Guid organizationId, ProjectViewModel projectVM)
        {
            throw new NotImplementedException();
        }

        public MemberViewModel Add(Guid organizationId, MemberViewModel memberVM)
        {
            throw new NotImplementedException();
        }

        public OrganizationViewModel Get(Guid organzationId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid organizationId)
        {
            throw new NotImplementedException();
        }
    }
}
