using BTT.Domain.Common.Models;
using BTT.Domain.Contracts;
using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Organizations;
using System;
using System.Collections.Generic;

namespace BTT.Domain.Models.Projects
{
    public class Project : Entity, IAggregateRoot, IRangeableDateTime, IMutableDetail
    {
        private Project()
        {
        }

        public Project(Organization organization,
            string title, string description, DateTime dueDate)
        {
            if (organization is null)
                throw new ArgumentNullException(nameof(organization));
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));

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

        public virtual Organization Organization { get; private set; }

        public Guid OrganizationId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public DateTime DateCreated { get; private set; }

        public DateTime EndDueDate { get; private set; }

        private readonly List<Issue> _issues;

        public virtual IReadOnlyCollection<Issue> Issues
        {
            get => _issues.AsReadOnly();
        }

        private readonly List<ProjectMember> _projectMembers;

        public virtual IReadOnlyCollection<ProjectMember> ProjectMembers
        {
            get => _projectMembers.AsReadOnly();
        }

        public void ChangeName(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            this.Title = title;
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));

            this.Description = description;
        }

        public void ChangeDueDate(DateTime dueDate)
        {
            this.EndDueDate = dueDate;
        }

        public void AddProjectMember(ProjectMember member)
        {
            _projectMembers.Add(member);
        }

        public void AddProjectIssue(Issue issue)
        {
            _issues.Add(issue);
        }

        public void RemoveProjectMember(ProjectMember member)
        {
            _projectMembers.Remove(member);
        }

        public void RemoveProjectIssue(Issue issue)
        {
            _issues.Remove(issue);
        }

        private void ThrowOnNullOrEmptyString(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));
        }
    }
}