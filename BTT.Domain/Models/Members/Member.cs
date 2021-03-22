using BTT.Domain.Common.Models;
using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Notifications;
using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Members
{
    public class Member : Entity, IAggregateRoot
    {
        private Member()
        {
        }

        public Member(string firstName, string lastName, string email, string password, Organization organization)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName));

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameof(lastName));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            this.Id = Guid.NewGuid();
            this.OrganizationId = organization.Id;
            this.Organization = organization;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;

            _memberProjects = new List<ProjectMember>();
            _issues = new List<Issue>();
            //_notifications = new List<BaseNotification>();
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public Guid OrganizationId { get; private set; }

        public virtual Organization Organization { get; private set; }

        private readonly List<ProjectMember> _memberProjects;

        public virtual IReadOnlyCollection<ProjectMember> MemberProjects {
            get => _memberProjects.AsReadOnly();
        }

        private readonly List<Issue> _issues;

        public virtual IReadOnlyCollection<Issue> Issues {
            get => _issues.AsReadOnly();
        }

        //private List<BaseNotification> _notifications;
        //public IReadOnlyCollection<BaseNotification> Notifications {
        //    get => _notifications.AsReadOnly();
        //}

        public void AddProject(ProjectMember project)
        {
            _memberProjects.Add(project);

            //AddDomainEvent(new ProjectCreated(project));
        }

        public void RemoveProject(ProjectMember project)
        {
            _memberProjects.Remove(project);
        }

        //public void RemoveProjectById(Guid id)
        //{
        //    _projects.RemoveAll(p => p.Id == id);
        //}

        public void AddIssue(Issue issue)
        {
            _issues.Add(issue);
        }

        public void RemoveIssue(Issue issue)
        {
            _issues.Remove(issue);
        }

        public void AddNotification(BaseNotification notification)
        {
            //_notifications.Add(notification);
        }

        public void RemoveNotification(BaseNotification notification)
        {
           // _notifications.Remove(notification);
        }
    }
}