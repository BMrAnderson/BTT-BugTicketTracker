
using BTT.Domain.Common.Validation;
using BTT.Domain.Contracts;
using BTT.Domain.Exceptions;
using System;
using System.Text;

namespace BTT.Domain.Models.Issues
{
    public record Attachment : IDateTime, IMutableDetail
    {
        private Attachment() { }

        public Attachment(string filename, string description)
        {
            Validate(filename, description);

            this.Filename = filename;
            this.Description = description;
            this.DateCreated = DateTime.Now;
        }

        public string Filename { get; private set; }

        public string Description { get; private set; }

        public DateTime DateCreated { get; private set; }

        public void ChangeDescription(string description)
        {
            Validation.CheckNull(description, nameof(description));

            this.Description = description;
        }

        public void ChangeName(string name)
        {
            Validation.CheckNull(name, nameof(name));

            this.Filename = name;
        }

        private void Validate(string filename, string description)
        {
            ValidateDescription(description);
            ValidateName(filename);
        }

        private void ValidateName(string filename)
        {
            Validation.CheckNull(filename, nameof(filename));
            Validation.CheckStringLength<InvalidAttachmentException>(
                filename, 
                ValidStringConstants.MinNameLength,
                ValidStringConstants.MaxNameLength,
                nameof(filename));                    
        }

        private void ValidateDescription(string description)
        {
            Validation.CheckNull(description, nameof(description));
            Validation.CheckStringLength<InvalidAttachmentException>(
                description,
                ValidStringConstants.MinDescriptionLength,
                ValidStringConstants.MaxDescriptionLength,
                nameof(description));
        }

    }
}