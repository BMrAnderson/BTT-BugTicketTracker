
using BTT.Domain.Common.Validation;
using BTT.Domain.Contracts;
using BTT.Domain.Exceptions;
using System;

namespace BTT.Domain.Models.Issues
{
    public record Comment : IDateTime
    {
        private Comment() { }

        public Comment(string text, DateTime dateCommented)
        {
            Validate(text);

            this.Text = text;
            this.DateCreated = dateCommented;
        }

        public string Text { get; private set; }

        public DateTime DateCreated { get; private set; }

        private void Validate(string text)
        {
            Validation.CheckNull(text, nameof(text));
            Validation.CheckStringLength<InvalidCommentException>(
                text,
                ValidStringConstants.MinTextLength,
                ValidStringConstants.MaxTextLength,
                nameof(text)
                );
        }
    }
}