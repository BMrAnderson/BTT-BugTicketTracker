using BTT.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.API.Extensions
{
    public static class ExceptionSanitizerExtensions
    {
        public static ResponseMessage SanitizeException(this Exception ex)
        {
            var response = new ResponseMessage();

            response.ExceptionType = ex.ToString();
            response.StackTrace = ex.StackTrace;
            response.Message = ex.Message;

            return response;
        }

        public static Response<T> SanitizeException<T>(this Exception ex)
        {
            var response = new Response<T>();

            response.ExceptionType = ex.ToString();
            response.StackTrace = ex.StackTrace;
            response.Message = ex.Message;

            return response;
        }
    }
}
