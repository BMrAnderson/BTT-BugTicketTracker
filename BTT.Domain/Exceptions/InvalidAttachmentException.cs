using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Exceptions
{
    public class InvalidAttachmentException : InvalidIssueException
    {
        public InvalidAttachmentException()
        {

        }

        public InvalidAttachmentException(string message) : base(message)
        {
            this.Error = message;
        }
    }
}
