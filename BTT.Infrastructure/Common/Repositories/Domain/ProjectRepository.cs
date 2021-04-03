using BTT.Domain.Common.Repository;
using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Projects;
using BTT.Infrastructure.Common.Persistence;
using BTT.Infrastructure.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTT.Infrastructure.Common.Repositories
{
    public class ProjectRepository : EFRepository<Project>, IProjectRepository
    {     
        public ProjectRepository(IssueTicketTrackerDBContext context): base(context)
        {
        }

        public IEnumerable<Project> GetProjectsByDueDate(DateTime dateTime)
        {
           return this._entities.Where(p => p.EndDueDate == dateTime);
        }
    }
}