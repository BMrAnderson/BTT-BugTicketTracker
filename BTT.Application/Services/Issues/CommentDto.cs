using System;

namespace BTT.Application.Services.Issues
{
    public class CommentDto
    {
        public Guid IssueId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
    }
}