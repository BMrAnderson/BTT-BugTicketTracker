using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Exceptions
{
    public class InvalidOrganizationException : BaseDomainException
    {
        public InvalidOrganizationException()
        {
        }

        public InvalidOrganizationException(string message) => this.Error = message;
    }
}
