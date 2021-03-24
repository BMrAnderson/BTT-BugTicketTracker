using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Application.Services.Issues
{
    public class CommentDto
    {
        public Guid IssueId { get; set; }
        public string Text { get; set; }
        public DateTime DateCommented { get; set; }
    }
}
      