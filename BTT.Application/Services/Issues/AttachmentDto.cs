using System;

namespace BTT.Application.Services.Issues
{
    public class AttachmentDto
    {
        public Guid IssueId { get; set; }
        public string Filename { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}