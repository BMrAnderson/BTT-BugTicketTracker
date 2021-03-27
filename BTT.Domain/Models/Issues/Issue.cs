using BTT.Domain.Common.Models;
using BTT.Domain.Contracts;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;
using BTT.Domain.Exceptions;
using BTT.Domain.Common.Validation;

namespace BTT.Domain.Models.Issues
{
    public class Issue : Entity, IAggregateRoot, IRangeableDateTime, IMutableDetail
    {
        private Issue()
        {
        }

        public Issue(Member assignedMember, Project assignedProject,
            string title, string description, Priority priority, DateTime dueDate)
        {
            Validate(assignedMember, assignedProject, title, description);

            this.Id = Guid.NewGuid();
            this.ProjectId = assignedProject.Id;
            this.MemberId = assignedMember.Id;
            this.Project = assignedProject;
            this.Member = assignedMember;
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.EndDueDate = dueDate;
            this.DateCreated = DateTime.Now;

            _comments = new List<Comment>();
            _attachments = new List<Attachment>();
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public DateTime EndDueDate { get; private set; }
        
        public DateTime DateCreated { get; private set; }

        public Priority Priority { get; private set; }

        public Guid ProjectId { get; private set; }

        public Guid MemberId { get; private set; }

        public virtual Project Project { get; private set; }

        public virtual Member Member { get; private set; }

        private readonly List<Comment> _comments;

        public virtual IReadOnlyCollection<Comment> Comments
        {
            get => _comments.AsReadOnly();
        }

        private readonly List<Attachment> _attachments;

        public virtual IReadOnlyCollection<Attachment> Attachments
        {
            get => _attachments.AsReadOnly();
        }

        public void ChangeDueDate(DateTime date)
        {
            this.EndDueDate = date;
        }

        public void ChangeName(string name)
        {
            ValidateTitle(name);

            this.Title = name;
        }

        public void ChangeDescription(string description)
        {
            ValidateDescription(description);

            this.Description = description;
        }

        public void ChangePriority(Priority priority)
        {
            this.Priority = Priority;
        }

        public void AddComment(Comment comment)
        {
            ValidateComment(comment);

            _comments.Add(comment);

            //AddDomainEvent(new CommentAdded(comment));
        }

        public void RemoveComment(Comment comment)
        {
            ValidateComment(comment);

            _comments.Remove(comment);
        }

        public void AddAttachment(Attachment attachment)
        {
            ValidateAttachment(attachment);

            _attachments.Add(attachment);

            //AddDomainEvent(new AttachmentAdded(attachment));
        }

        public void RemoveAttachment(Attachment attachment)
        {
            ValidateAttachment(attachment);

            _attachments.Remove(attachment);
        }

        private void Validate(Member assignedMember, Project assignedProject, 
            string title, string description)
        {
            ValidateMember(assignedMember);
            ValidateProject(assignedProject);
            ValidateDescription(description);
            ValidateTitle(title);
        }

        private void ValidateMember(Member assignedMember)
        {
            Validation.CheckNull(assignedMember, nameof(assignedMember));
        }

        private void ValidateProject(Project assignedProject)
        {
            Validation.CheckNull(assignedProject, nameof(assignedProject));
        }

        private void ValidateAttachment(Attachment attachment)
        {
            Validation.CheckNull(attachment, nameof(attachment));
        }

        private void ValidateComment(Comment comment)
        {
            Validation.CheckNull(comment, nameof(comment));
        }

        private void ValidateTitle(string title)
        {
            Validation.CheckStringLength<InvalidIssueException>(
                title,
                ValidStringConstants.MinNameLength,
                ValidStringConstants.MaxNameLength,
                nameof(title)
                );
        }

        private void ValidateDescription(string description)
        {
            Validation.CheckStringLength<InvalidIssueException>(
                description,
                ValidStringConstants.MinDescriptionLength,
                ValidStringConstants.MaxDescriptionLength,
                nameof(description)
                );
        }
    }
}