using System;

namespace BTT.Domain.Models.Issues
{
    public record Comment
    {
        private Comment() { }

        public Comment(string text, DateTime dateCommented)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));

            this.Text = text;
            this.DateCommented = dateCommented;
        }

        public string Text { get; private set; }

        public DateTime DateCommented { get; private set; }
    }
}