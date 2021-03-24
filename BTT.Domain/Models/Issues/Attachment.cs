﻿using System;

namespace BTT.Domain.Models.Issues
{
    public record Attachment
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
            this.DateAdded = DateTime.Now;
        }

        public string FileName { get; private set; }

        public string Description { get; private set; }

        public DateTime DateAdded { get; private set; }

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