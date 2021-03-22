using BTT.Domain.Common.Repository;

namespace BTT.Domain.Models.Organizations
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        Organization GetOrganizationByName(string name);
    }
}