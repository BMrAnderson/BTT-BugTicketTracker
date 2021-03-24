using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Exceptions
{
    public class BaseDomainException : Exception
    {
        private string error;

        public string Error 
        {
            get => error ?? base.Message;
            set => error = value;
        }
    }
}
