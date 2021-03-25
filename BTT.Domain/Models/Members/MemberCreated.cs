﻿using BTT.Domain.Common.Events;
using System;

namespace BTT.Domain.Models.Members
{
    public class MemberCreated : IDomainEvent<Member>
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public Member Data { get; }

        public MemberCreated(Member member)
        {
            this.Data = member;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTime.Now;
        }
    }
}