using BTT.Domain.Common.Models;
using BTT.Domain.Contracts;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;
using BTT.Domain.Common.Extensions;
using BTT.Domain.Exceptions;

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
            ValidatePrimitiveArgs(title, description);
            ValidateDomainRootArgs(assignedMember, assignedProject);
          

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
            this.Title = name;
        }

        public void ChangeDescription(string description)
        {
            this.Description = description;
        }

        public void ChangePriority(Priority priority)
        {
            this.Priority = Priority;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);

            //AddDomainEvent(new CommentAdded(comment));
        }

        public void RemoveComment(Comment comment)
        {
            _comments.Remove(comment);
        }

        public void AddAttachment(Attachment attachment)
        {
            _attachments.Add(attachment);

            //AddDomainEvent(new AttachmentAdded(attachment));
        }

        public void RemoveAttachment(Attachment attachment)
        {
            _attachments.Remove(attachment);
        }

        private void ValidatePrimitiveArgs(params string[] args)
        {
            foreach (var arg in args)
            {
                arg.CheckNull(nameof(arg));
            }
        }

        private void ValidateDomainRootArgs(params IAggregateRoot[] args)
        {
            foreach (var arg in args)
            {
                arg.CheckNull(nameof(arg));
            }
        }


    }
}