using BTT.Domain.Common.Events;
using BTT.Domain.Common.Validation;
using System;

namespace BTT.Domain.Models.Members
{
    public class MemberCreated : IDomainEvent
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public Member Member { get; }

        public MemberCreated(Member member)
        {
            Validation.CheckNull(member, nameof(member));

            this.Member = member;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTime.Now;
        }
    }
}