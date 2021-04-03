using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BTT.API
{
    public class ResponseMessage
    {
        public string Message { get; set; }
        public string ExceptionType { get; set; }
        public string StackTrace { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
