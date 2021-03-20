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
        public Issue(Member memberAssigned, Member submitter, Project assignedProject,
            string title, string description, DateTimeOffset dueDate)
        {
            if (memberAssigned is null)
                throw new ArgumentNullException(nameof(memberAssigned));

         
            this.Id = Guid.NewGuid();
            this.AssignedMemberId = memberAssigned.Id;
            this.AssignedProjectId = assignedProject.Id;
            this.SubmitterId = submitter.Id;
            this.Title = title;
            this.Description = description;
            this.DueDate = dueDate;

            _comments = new List<Comment>();
            _attachments = new List<Attachment>();
        }

        public string Title { get; private set; }
        
        public string Description { get; private set; }

        public DateTimeOffset DateSubmitted { get; private set; }

        public DateTimeOffset DueDate { get; private set; }

        public Guid AssignedMemberId { get; private set; }

        public Guid SubmitterId { get; private set; }

        public Guid AssignedProjectId { get; private set; }

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

            AddDomainEvent(new CommentAdded(comment));
        }

        public void RemoveCommentById(Guid id)
        {
            _comments.RemoveAll(c => c.Id == id);
        }

        public void RemoveComment(Comment comment)
        {
            _comments.Remove(comment);
        }

        public void AddAttachment(Attachment attachment)
        {
            _attachments.Add(attachment);

            AddDomainEvent(new AttachmentAdded(attachment));
        }

        public void RemoveAttachmentById(Guid id)
        {
            _attachments.RemoveAll(a => a.Id == id);
        }

        public void RemoveAttachment(Attachment attachment)
        {
            _attachments.Remove(attachment);
        }
    }
}
