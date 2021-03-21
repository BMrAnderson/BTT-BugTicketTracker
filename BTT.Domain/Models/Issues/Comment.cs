using BTT.Domain.Common.Models;
using BTT.Domain.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Issues
{
    public class Comment : Entity
    {
        public Comment(Member member, Issue issue, string text, DateTimeOffset dateCommented)
        {
            this.Id = Guid.NewGuid();
            this.IssueId = issue.Id;
            this.Text = text;
            this.DateCommented = dateCommented;
        }
        public Guid MemberId { get; private set; }

        public Guid IssueId { get; private set; }

        public string Text { get; private set; }

        public DateTimeOffset DateCommented { get; private set; }
    }
}
