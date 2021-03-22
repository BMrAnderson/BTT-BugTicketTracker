using BTT.Domain.Common.Events;
using System;

namespace BTT.Domain.Models.Members
{
    public class MemberCreated : IDomainEvent
    {
        public Guid EventId { get; }

        public DateTimeOffset EventDateOccured { get; }

        public Member Member { get; }

        public MemberCreated(Member member)
        {
            this.Member = member;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTimeOffset.Now;
        }
    }
}