using BTT.Domain.Common.Models;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Projects
{
    public class Project : Entity, IAggregateRoot
    {
        public Project(Member owner, Organization organization, 
            string title, string description, DateTimeOffset dueDate )
        {
            this.Id = Guid.NewGuid();
            this.OwnerId = owner.Id;
            //this.OrganizationId = organization
            this.Title = title;
            this.Description = description;
            this.DueDate = dueDate;
            this.DateCreated = DateTimeOffset.Now;

            this._projectIssues = new List<ProjectIssue>();
            this._projectMembers = new List<ProjectMember>();
        }

        public Guid OwnerId { get; private set; }

        public Guid OrganizationId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public DateTimeOffset DateCreated { get; private set; }

        public DateTimeOffset DueDate { get; private set; }

        private List<ProjectIssue> _projectIssues;
        public IReadOnlyCollection<ProjectIssue> ProjectIssues {
            get => _projectIssues.AsReadOnly(); 
        }

        private List<ProjectMember> _projectMembers;
        public IReadOnlyCollection<ProjectMember> ProjectMembers {
            get => _projectMembers.AsReadOnly(); 
        }

        public void AddProjectMember(ProjectMember member)
        {
            _projectMembers.Add(member);
        }

        public void AddProjectIssue(ProjectIssue projectIssue)
        {
            _projectIssues.Add(projectIssue);
        }

        public void RemoveProjectMember(ProjectMember member)
        {
            _projectMembers.Remove(member);
        }

        public void RemoveProjectIssue(ProjectIssue issue)
        {
            _projectIssues.Remove(issue);
        }
    }
}
