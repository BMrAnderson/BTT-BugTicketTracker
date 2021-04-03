using BTT.Domain.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Organizations
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        Organization GetOrganizationByName(string name);
    }
}
