using BTT.Domain.Common.Models;
using BTT.Domain.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Issues
{
    public record Attachment
    {
        public Attachment(string filename, string description)
        {
            this.FileName = filename;
            this.Description = description;
            this.DateAdded = DateTimeOffset.Now;
        }

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
