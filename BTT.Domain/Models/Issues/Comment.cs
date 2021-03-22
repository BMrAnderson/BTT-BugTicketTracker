using BTT.Domain.Common.Models;
using BTT.Domain.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Issues
{
    public record Comment 
    {
        public Comment(string text, DateTimeOffset dateCommented)
        {
            this.Text = text;
            this.DateCommented = dateCommented;
        }

        public string Text { get; private set; }

        public DateTimeOffset DateCommented { get; private set; }
    }
}
