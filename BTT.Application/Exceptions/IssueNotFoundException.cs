using BTT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Application.Exceptions
{
    public class IssueNotFoundException : BaseDomainException
    {
        public IssueNotFoundException()
        {

        }

        public IssueNotFoundException(string message)
        {
            this.Error = message;
        }
    }
}
