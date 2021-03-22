using BTT.Domain.Common.Models;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Issues
{
    public class Issue : Entity, IAggregateRoot
    {
        private Issue() { }

        public Issue(Member assignedMember, Project assignedProject,
            string title, string description, Priority priority , DateTimeOffset dueDate)
        {
            if (assignedMember is null)
                throw new ArgumentNullException(nameof(assignedMember));

         
            this.Id = Guid.NewGuid();
            this.AssignedMemberId = assignedMember.Id;
            this.AssignedProjectId = assignedProject.Id;
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.DueDate = dueDate;
            this.DateSubmitted = DateTimeOffset.Now;

            _comments = new List<Comment>();
            _attachments = new List<Attachment>();
        }

        public string Title { get; private set; }
        
        public string Description { get; private set; }

        public DateTimeOffset DateSubmitted { get; private set; }

        public DateTimeOffset DueDate { get; private set; }

        public Guid AssignedMemberId { get; private set; }

        public Guid AssignedProjectId { get; private set; }

        public Priority Priority { get; private set; }

        private readonly List<Comment> _comments;
        public IReadOnlyCollection<Comment> Comments { 
            get => _comments.AsReadOnly(); 
        }

        private readonly List<Attachment> _attachments;
        public IReadOnlyCollection<Attachment> Attachments {
            get => _attachments.AsReadOnly();  
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
    }
}
