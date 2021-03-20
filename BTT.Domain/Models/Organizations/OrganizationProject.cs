using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Organizations
{
    public class OrganizationProject
    {
        public Guid OrganizationId { get; }

        public Guid ProjectId { get; }

        public OrganizationProject(Organization organization, Project project)
        {
            this.OrganizationId = organization.Id;
            this.ProjectId = project.Id;
        }
    }
}
