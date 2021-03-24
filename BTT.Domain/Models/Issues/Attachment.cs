using BTT.Domain.Contracts;
using System;

namespace BTT.Domain.Models.Issues
{
    public record Attachment : IDateTime, IMutableDetail
    {
        private Attachment() { }

        public Attachment(string filename, string description)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException(nameof(filename));
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));

            this.FileName = filename;
            this.Description = description;
            this.DateCreated = DateTime.Now;
        }

        public string FileName { get; private set; }

        public string Description { get; private set; }

        public DateTime DateCreated { get; private set; }

        public void ChangeDescription(string description)
        {
            this.Description = description;
        }

        public void ChangeName(string name)
        {
            this.FileName = name;
        }
    }
}