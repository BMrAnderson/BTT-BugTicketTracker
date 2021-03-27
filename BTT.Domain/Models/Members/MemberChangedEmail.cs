using BTT.Domain.Common.Events;
using BTT.Domain.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Members
{
    public class MemberChangedEmail : IDomainEvent
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public string Email { get; }

        public MemberChangedEmail(string newEmail)
        {
            Validation.CheckNull(newEmail, nameof(newEmail));

            this.Email = newEmail;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTime.Now;
        }
    }
}
