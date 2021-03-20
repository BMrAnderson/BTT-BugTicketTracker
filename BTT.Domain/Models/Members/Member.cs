using BTT.Domain.Common.Models;
using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Notifications;
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
        public Member(string firstName, string lastName, string email, string password, Member supervisor)
        {
            if (string.IsNullOrEmpty(firstName)) 
                throw new ArgumentNullException(nameof(firstName));
           
            if (string.IsNullOrEmpty(lastName)) 
                throw new ArgumentNullException(nameof(lastName));
            
            if (string.IsNullOrEmpty(email)) 
                throw new ArgumentNullException(nameof(email));
            
            if (string.IsNullOrEmpty(password)) 
                throw new ArgumentNullException(nameof(password));
            
            if (supervisor is null) 
                throw new ArgumentNullException(nameof(supervisor));

            this.Id = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.SupervisorId = supervisor.Id;

            _projects = new List<Project>();
            _issues = new List<Issue>();
            _notifications = new List<BaseNotification>();
        }
        
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public Guid SupervisorId { get; private set; }

        private List<Project> _projects;
        public IReadOnlyCollection<Project> Projects { 
            get => _projects.AsReadOnly(); 
        }

        private List<Issue> _issues;
        public IReadOnlyCollection<Issue> Issues {
            get => _issues.AsReadOnly();
        }

        private List<BaseNotification> _notifications;
        public IReadOnlyCollection<INotification> Notifications {
            get => _notifications.AsReadOnly();
        }

        public void AddProject(Project project)
        {
            _projects.Add(project);

            AddDomainEvent(new ProjectCreated(project));
        }

        public void RemoveProject(Project project)
        {
            _projects.Remove(project);
        }

        public void RemoveProjectById(Guid id)
        {
            _projects.RemoveAll(p => p.Id == id);
        }

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
            _notifications.Add(notification);
        }

        public void RemoveNotification(BaseNotification notification)
        {
            _notifications.Remove(notification);
        }
    }
}
