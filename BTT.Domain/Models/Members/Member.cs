using BTT.Domain.Common.Extensions;
using BTT.Domain.Common.Models;
using BTT.Domain.Exceptions;
using BTT.Domain.Models.Email;
using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Notifications;
using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BTT.Domain.Models.Members
{
    public class Member : Entity, IAggregateRoot
    {
        private readonly List<Issue> _issues;

        private readonly List<ProjectMember> _memberProjects;

        private readonly List<BaseDomainNotification> _notifications;

        public Member(string firstName, string lastName, string email, string password, Organization organization)
        {

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

        private Member() {}

        public string Email { get; private set; }
        
        public string FirstName { get; private set; }
        
        public string LastName { get; private set; }
        
        public string Password { get; private set; }

        public virtual Organization Organization { get; private set; }

        public Guid OrganizationId { get; private set; }

        public virtual IReadOnlyCollection<Issue> Issues
        {
            get => _issues.AsReadOnly();
        }
        
        public virtual IReadOnlyCollection<ProjectMember> MemberProjects
        {
            get => _memberProjects.AsReadOnly();
        }
    
        public virtual IReadOnlyCollection<BaseDomainNotification> Notifications
        {
            get => _notifications.AsReadOnly();
        }

        public void AddIssue(Issue issue)
        {
            _issues.Add(issue);
        }

        public void RemoveIssue(Issue issue)
        {
            _issues.Remove(issue);
        }

        public void AddNotification(BaseDomainNotification notification)
        {
            _notifications.Add(notification);
        }

        public void RemoveNotification(BaseDomainNotification notification)
        {
            _notifications.Remove(notification);
        }

        public void AddProject(ProjectMember project)
        {
            _memberProjects.Add(project);

            //AddDomainEvent(new ProjectCreated(project));
        }

        public void RemoveProject(ProjectMember project)
        {
            _memberProjects.Remove(project);
        }

        private void ValidateArgs(string firstName, string lastName, string email, string password, Organization organization)
        {
            firstName.CheckNull(nameof(firstName));
            lastName.CheckNull(nameof(lastName));
            email.CheckNull(nameof(email));
            password.CheckNull(nameof(password));
            organization.CheckNull(nameof(organization));     
        }

        private void ValidateEmail(string email)
        {
            string pattern = EmailConstants.EmailRegexPattern;

            var regex = new Regex(pattern);

            email.ThrowIfConditionNotMet<InvalidMemberException>
                ("Member email was not valid.", e => regex.IsMatch(email));
        }

    }
}