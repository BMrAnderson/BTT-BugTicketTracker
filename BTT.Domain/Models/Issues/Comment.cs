using BTT.Domain.Contracts;
using System;

namespace BTT.Domain.Models.Issues
{
    public record Comment : IDateTime
    {
        private Comment() { }

        public Comment(string text, DateTime dateCommented)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));

            this.Text = text;
            this.DateCreated = dateCommented;
        }

        public string Text { get; private set; }

        public DateTime DateCreated { get; private set; }
    }
}