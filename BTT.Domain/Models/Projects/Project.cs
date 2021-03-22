using BTT.Domain.Common.Models;
using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Organizations;
using System;
using System.Collections.Generic;

namespace BTT.Domain.Models.Projects
{
    public class Project : Entity, IAggregateRoot
    {
        private Project()
        {
        }

        public Project(Organization organization,
            string title, string description, DateTimeOffset dueDate)
        {
            this.Id = Guid.NewGuid();
            this.OrganizationId = organization.Id;
            this.Title = title;
            this.Description = description;
            this.DueDate = dueDate;
            this.DateCreated = DateTimeOffset.Now;

            this._issues = new List<Issue>();
            this._projectMembers = new List<ProjectMember>();
        }

        public Guid OrganizationId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public DateTimeOffset DateCreated { get; private set; }

        public DateTimeOffset DueDate { get; private set; }

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
    }
}