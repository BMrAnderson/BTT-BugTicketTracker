using BTT.Domain.Common.Models;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;

namespace BTT.Domain.Models.Organizations
{
    public class Organization : Entity, IAggregateRoot
    {
        private Organization()
        {
        }

        public Organization(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            this.Id = Guid.NewGuid();
            this.Name = name;
            this.OrganizationStartedDate = DateTime.Now;

            _members = new List<Member>();
            _projects = new List<Project>();
        }

        public string Name { get; private set; }

        public DateTime OrganizationStartedDate { get; private set; }

        private readonly List<Project> _projects;

        public virtual IReadOnlyCollection<Project> Projects
        {
            get => _projects.AsReadOnly();
        }

        private readonly List<Member> _members;

        public virtual IReadOnlyCollection<Member> Members
        {
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