using BTT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Application.Exceptions
{
    public class ProjectNotFoundException : BaseDomainException
    {
        public ProjectNotFoundException(string message)
        {
            this.Error = message;
        }
    }
}
