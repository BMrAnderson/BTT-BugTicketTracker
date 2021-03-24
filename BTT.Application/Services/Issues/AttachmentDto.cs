using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Application.Services.Issues
{
    public class AttachmentDto
    {
        public Guid IssueId { get; set; }
        public string Filename { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
