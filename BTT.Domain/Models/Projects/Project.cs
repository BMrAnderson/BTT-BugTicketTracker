using BTT.Domain.Common.Models;
using BTT.Domain.Models.Issues;
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
        private Project() { }

        public Project(Organization organization, 
            string title, string description, DateTimeOffset dueDate )
        {
            this.Id = Guid.NewGuid();
            this.OrganizationId = organization.Id;
            this.Title = title;
            this.Description = description;
            this.DueDate = dueDate;
            this.DateCreated = DateTimeOffset.Now;

            this._issues = new List<Issue>();
            this._members = new List<Member>();
        }

        public Guid OrganizationId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public DateTimeOffset DateCreated { get; private set; }

        public DateTimeOffset DueDate { get; private set; }

        private List<Issue> _issues;
        public IReadOnlyCollection<Issue> Issues {
            get => _issues.AsReadOnly(); 
        }

        private List<Member> _members;
        public IReadOnlyCollection<Member> Members {
            get => _members.AsReadOnly(); 
        }

        public void AddProjectMember(Member member)
        {
            _members.Add(member);
        }

        public void AddProjectIssue(Issue issue)
        {
            _issues.Add(issue);
        }

        public void RemoveProjectMember(Member member)
        {
            _members.Remove(member);
        }

        public void RemoveProjectIssue(Issue issue)
        {
            _issues.Remove(issue);
        }
    }
}
