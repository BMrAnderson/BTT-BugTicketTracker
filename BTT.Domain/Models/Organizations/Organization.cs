using BTT.Domain.Common.Models;
using BTT.Domain.Common.Validation;
using BTT.Domain.Contracts;
using BTT.Domain.Exceptions;
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
            Validate(name);

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
            ValidateMember(member);

            _members.Add(member);
        }

        public void AddOrganizationProject(Project project)
        {
            ValidateProject(project);

            _projects.Add(project);
        }
        public void RemoveOrganizationMember(Member member)
        {
            ValidateMember(member);

            _members.Remove(member);
        }

        public void RemoveOrganizationProject(Project project)
        {
            ValidateProject(project);
            
            _projects.Remove(project);
        }

        private void ValidateMember(Member member)
        {
            Validation.CheckNull(member, nameof(member));
        }

        private void ValidateProject(Project project)
        {
            Validation.CheckNull(project, nameof(project));
        }

        private void Validate(string name)
        {
            Validation.CheckStringLength<InvalidOrganizationException>(
                name,
                ValidStringConstants.MinNameLength,
                ValidStringConstants.MaxNameLength,
                nameof(name)
                );
        }
    }
}