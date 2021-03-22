using BTT.Domain.Common.Repository;
using System;
using System.Collections.Generic;

namespace BTT.Domain.Models.Projects
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> GetProjectsByOrganizationId(Guid id);
    }
}