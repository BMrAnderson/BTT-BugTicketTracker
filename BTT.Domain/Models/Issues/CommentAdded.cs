﻿using BTT.Domain.Common.Events;
using System;

namespace BTT.Domain.Models.Issues
{
    public class CommentAdded : IDomainEvent
    {
        public Guid EventId { get; }

        public DateTimeOffset EventDateOccured { get; }

        public Comment Comment { get; }

        public CommentAdded(Comment comment)
        {
            this.EventId = Guid.NewGuid();
            this.Comment = comment;
            this.EventDateOccured = DateTimeOffset.Now;
        }
    }
}