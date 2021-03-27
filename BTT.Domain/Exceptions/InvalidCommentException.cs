using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Exceptions
{
    public class InvalidCommentException : InvalidIssueException
    {
        public InvalidCommentException() 
        { 
        }

        public InvalidCommentException(string message) => this.Error = message;
    }
}
