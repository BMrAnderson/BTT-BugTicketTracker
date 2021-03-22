using BTT.Domain.Common.Models;
using BTT.Domain.Models.Members;
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
        private Organization() { }

        public Organization(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;

            _members = new List<Member>();
            _projects = new List<Project>();
        }
        public string Name { get; private set; }

        public DateTimeOffset OrganizationStartedDate { get; private set; }

        private List<Project> _projects;
        public IReadOnlyCollection<Project> Projects { 
            get => _projects.AsReadOnly(); 
        }

        private List<Member> _members;
        public IReadOnlyCollection<Member> Members {
            get => _members.AsReadOnly();
        }

        public void AddOrganizationProject(Project project)
        {
            _projects.Add(project);
        }

        public void AddOrganizationMember(Member member)
        {
            _members.Add(member);
        }

        public void RemoveOrganizationProject(Project project)
        {
            _projects.Remove(project);
        }

        public void RemoveOrganizationMember(Member member)
        {
            _members.Remove(member);
        }
    }
}
