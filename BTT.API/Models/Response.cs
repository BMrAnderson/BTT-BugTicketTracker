using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.API.Models
{
    public class Response<TData> : ResponseMessage
    {
        public TData Result { get; set; }
    }
}
