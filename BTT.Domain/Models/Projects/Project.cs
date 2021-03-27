using BTT.Domain.Common.Models;
using BTT.Domain.Common.Validation;
using BTT.Domain.Contracts;
using BTT.Domain.Exceptions;
using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Organizations;
using System;
using System.Collections.Generic;

namespace BTT.Domain.Models.Projects
{
    public class Project : Entity, IAggregateRoot, IRangeableDateTime, IMutableDetail
    {
        private readonly List<Issue> _issues;

        private readonly List<ProjectMember> _projectMembers;

        public Project(Organization organization, string title, 
            string description, DateTime dueDate)
        {
            Validate(title, description, organization);

            this.Id = Guid.NewGuid();
            this.OrganizationId = organization.Id;
            this.Organization = organization;
            this.Title = title;
            this.Description = description;
            this.EndDueDate = dueDate;
            this.DateCreated = DateTime.Now;

            this._issues = new List<Issue>();
            this._projectMembers = new List<ProjectMember>();
        }

        private Project()
        {
        }

        public virtual Organization Organization { get; private set; }

        public Guid OrganizationId { get; private set; }

        public DateTime DateCreated { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }
        
        public DateTime EndDueDate { get; private set; }

        public virtual IReadOnlyCollection<Issue> Issues
        {
            get => _issues.AsReadOnly();
        }

        public virtual IReadOnlyCollection<ProjectMember> ProjectMembers
        {
            get => _projectMembers.AsReadOnly();
        }

        public void AddProjectIssue(Issue issue)
        {
            ValidateIssue(issue);

            _issues.Add(issue);
        }

        public void AddProjectMember(ProjectMember member)
        {
            ValidateMember(member);

            _projectMembers.Add(member);
        }

        public void ChangeDescription(string description)
        {
            ValidateDescription(description);

            this.Description = description;
        }

        public void ChangeDueDate(DateTime dueDate)
        {
            this.EndDueDate = dueDate;
        }

        public void ChangeName(string title)
        {
            ValidateTitle(title);

            this.Title = title;
        }
        public void RemoveProjectIssue(Issue issue)
        {
            ValidateIssue(issue);

            _issues.Remove(issue);
        }

        public void RemoveProjectMember(ProjectMember member)
        {
            ValidateMember(member);

            _projectMembers.Remove(member);
        }

        private void Validate(string title, string description, Organization organization)
        {
            ValidateTitle(title);
            ValidateDescription(description);
            ValidateOrganization(organization);
        }

        private void ValidateOrganization(Organization organization)
        {
            Validation.CheckNull(organization, nameof(organization));
        }

        private void ValidateIssue(Issue issue)
        {
            Validation.CheckNull(issue, nameof(issue));
        }

        private void ValidateMember(ProjectMember member)
        {
            Validation.CheckNull(member, nameof(member));
        }

        private void ValidateTitle(string title)
        {
            Validation.CheckStringLength<InvalidProjectException>(
                title,
                ValidStringConstants.MinNameLength,
                ValidStringConstants.MaxNameLength,
                nameof(title)
                );
        }

        private void ValidateDescription(string description)
        {
            Validation.CheckStringLength<InvalidProjectException>(
                description,
                ValidStringConstants.MinDescriptionLength,
                ValidStringConstants.MaxDescriptionLength,
                nameof(description)
                );
        }
    }
}