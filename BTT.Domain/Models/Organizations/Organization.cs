using BTT.Domain.Common.Extensions;
using BTT.Domain.Common.Models;
using BTT.Domain.Contracts;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;

namespace BTT.Domain.Models.Organizations
{
    public class Organization : Entity, IAggregateRoot, IDateTime
    {
        private readonly List<Member> _members;

        private readonly List<Project> _projects;

        public Organization(string name)
        {
            name.CheckNull(nameof(name));

            this.Id = Guid.NewGuid();
            this.Name = name;
            this.DateCreated = DateTime.Now;

            _members = new List<Member>();
            _projects = new List<Project>();
        }

        private Organization()
        {
        }
        
        public string Name { get; private set; }
        
        public DateTime DateCreated { get; private set; }
        
        public virtual IReadOnlyCollection<Member> Members
        {
            get => _members.AsReadOnly();
        }

        public virtual IReadOnlyCollection<Project> Projects
        {
            get => _projects.AsReadOnly();
        }
    
        public void AddOrganizationMember(Member member)
        {
            member.CheckNull(nameof(member));

            _members.Add(member);
        }

        public void AddOrganizationProject(Project project)
        {
            project.CheckNull(nameof(project));

            _projects.Add(project);
        }
        public void RemoveOrganizationMember(Member member)
        {
            member.CheckNull(nameof(member));

            _members.Remove(member);
        }

        public void RemoveOrganizationProject(Project project)
        {
            project.CheckNull(nameof(project));

            _projects.Remove(project);
        }
    }
}