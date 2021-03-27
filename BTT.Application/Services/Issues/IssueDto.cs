using BTT.Domain.Models.Issues;
using System;
using System.Collections.Generic;

namespace BTT.Application.Services.Issues
{
    public class IssueDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime EndDueDate { get; set; }
        public Priority Priority { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<AttachmentDto> Attachments { get; set; }
        public Guid MemberId { get; set; }
        public Guid ProjectId { get; set; }
    }
}