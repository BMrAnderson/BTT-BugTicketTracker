using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Exceptions
{
    public class InvalidIssueException : BaseDomainException
    {
        public InvalidIssueException()
        {
        }

        public InvalidIssueException(string message) => this.Error = message;
    }
}
