using BTT.Domain.Common.Models;
using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Organizations
{
    public class Organization : Entity, IAggregateRoot
    {
        public Organization(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public string Name { get; private set; }

        public DateTimeOffset OrganizationStartedDate { get; private set; }

        private List<OrganizationProject> _organizationProjects;
        public IReadOnlyCollection<OrganizationProject> OrganizationProjects { 
            get => _organizationProjects.AsReadOnly(); 
        }

        private List<OrganizationMember> _organizationMembers;
        public IReadOnlyCollection<OrganizationMember> OrganizationMembers {
            get => _organizationMembers.AsReadOnly();
        }

        public void AddOrganizationProject(OrganizationProject project)
        {
            _organizationProjects.Add(project);
        }

        public void AddOrganizationMember(OrganizationMember member)
        {
            _organizationMembers.Add(member);
        }

        public void RemoveOrganizationProject(OrganizationProject project)
        {
            _organizationProjects.Remove(project);
        }

        public void RemoveOrganizationMember(OrganizationMember member)
        {
            _organizationMembers.Remove(member);
        }
    }
}
