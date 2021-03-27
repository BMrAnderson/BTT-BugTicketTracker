using BTT.Domain.Common.Models;
using BTT.Domain.Common.Validation;
using BTT.Domain.Exceptions;
using BTT.Domain.Models.Email;
using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Notifications;
using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;
using System.Text;
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
            Validate(firstName, lastName, email, password, organization);

            this.Id = Guid.NewGuid();
            this.OrganizationId = organization.Id;
            this.Organization = organization;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;

            _memberProjects = new List<ProjectMember>();
            _issues = new List<Issue>();
            _notifications = new List<BaseDomainNotification>();
        }

        private Member() {}

        public void ChangeEmail(string email)
        {
            this.Email = email;

            PublishEvent(new MemberChangedEmail(email));
        }

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

        private void Validate(string firstName, string lastName, string email, string password, Organization organization)
        {
            ValidateFirstAndLastName(firstName, lastName);
            ValidateEmail(email);
            ValidatePassword(password);
           
            Validation.CheckNull(organization, nameof(organization));
        }

        private void ValidateFirstAndLastName(string firstName, string lastName)
        {
            Validation.CheckStringLength<InvalidMemberException>(
                firstName,
                ValidStringConstants.MinNameLength,
                ValidStringConstants.MaxNameLength,
                nameof(firstName));
            Validation.CheckStringLength<InvalidMemberException>(
                lastName,
                ValidStringConstants.MinNameLength,
                ValidStringConstants.MaxNameLength,
                nameof(lastName));
        }

        private void ValidatePassword(string password)
        {
            var rgxNumber = new Regex(ValidPasswordConstants.RgxNumber);
            var rgxUpperCase = new Regex(ValidPasswordConstants.RgxUpperCase);
            var rgxMinMaxChars = new Regex(ValidPasswordConstants.RgxMinMaxChars);
            var rgxLowerChar = new Regex(ValidPasswordConstants.RgxLowerChar);
            var rgxSymbols = new Regex(ValidPasswordConstants.RgxSymbols);

            int errorCount = 0;
            var stringErrorBuilder = new StringBuilder("Password must contain:");

            if (!rgxNumber.IsMatch(password))
            {
                stringErrorBuilder.AppendLine("atleast one number.");
                errorCount++;
            }       
            if (!rgxUpperCase.IsMatch(password))
            {
                stringErrorBuilder.AppendLine("one Uppercase letter.");
                errorCount++;
            }         
            if (!rgxMinMaxChars.IsMatch(password))
            {
                stringErrorBuilder.AppendLine("minimum 8 and max 12 characters.");
                errorCount++;
            }
            if (!rgxLowerChar.IsMatch(password))
            {
                stringErrorBuilder.AppendLine("one Lowercase letter.");
                errorCount++;
            }  
            if (!rgxSymbols.IsMatch(password))
            {
                stringErrorBuilder.AppendLine("one Special character.");
                errorCount++;
            }

            Validation.CheckCondition<InvalidMemberException>(
                errorCount == 0,
                stringErrorBuilder.ToString()
                );
        }

        private void ValidateEmail(string email)
        {
            var rgxEmail = new Regex(ValidEmailConstants.RgxEmail);

            Validation.CheckCondition<InvalidMemberException>(
                rgxEmail.IsMatch(email),
                "Email is not valid."
                );
        }

    }
}