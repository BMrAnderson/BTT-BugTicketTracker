using BTT.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Members
{
    public class MemberChangedEmail : IDomainEvent<String>
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public string Data { get; }

        public MemberChangedEmail(string newEmail)
        {
            this.Data = newEmail;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTime.Now;
        }
    }
}
