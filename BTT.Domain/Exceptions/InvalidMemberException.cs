using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Exceptions
{
    public class InvalidMemberException : BaseDomainException
    {
        public InvalidMemberException()
        {
        }

        public InvalidMemberException(string message) => this.Error = message;
    }
}
