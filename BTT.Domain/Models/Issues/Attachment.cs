using BTT.Domain.Common.Models;
using BTT.Domain.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Issues
{
    public class Attachment : Entity
    {
        public Attachment(Issue issue, Member member, string filename, string description)
        {
            this.Id = Guid.NewGuid();
            this.IssueId = issue.Id;
            this.MemberId = member.Id;
            this.FileName = filename;
            this.Description = description;
            this.DateAdded = DateTimeOffset.Now;
        }

        public Guid IssueId { get; private set; }

        public Guid MemberId { get; private set; }

        public string FileName { get; private set; }

        public string Description { get; private set; }

        public DateTimeOffset DateAdded { get; private set; }

        public void ChangeFileName(string filename)
        {
            FileName = filename;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }
    }
}
