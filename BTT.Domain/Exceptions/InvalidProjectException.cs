using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Exceptions
{
    public class InvalidProjectException : BaseDomainException
    {
        public InvalidProjectException()
        {
        }

        public InvalidProjectException(string message) => this.Error = message;
    }
}
