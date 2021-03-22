using System;

namespace BTT.Domain.Models.Issues
{
    public record Comment
    {
        private Comment() { }

        public Comment(string text, DateTimeOffset dateCommented)
        {
            this.Text = text;
            this.DateCommented = dateCommented;
        }

        public string Text { get; private set; }

        public DateTimeOffset DateCommented { get; private set; }
    }
}