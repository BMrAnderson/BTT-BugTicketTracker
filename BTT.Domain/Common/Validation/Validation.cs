using BTT.Domain.Common.Models;
using BTT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Common.Validation
{
    public static class Validation
    {
        public static void CheckNull(string data, string paramName = "Value")
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void CheckNull<T>(T data, string paramName = "Value")
            where T : class
        {
            if (data is null) 
            {
                throw new ArgumentNullException(paramName);
            } 
        }

        public static void CheckStringLength<TException>(string current, int minLength, int maxLength, string paramName = "Value")
            where TException : BaseDomainException, new()
        {
            CheckNull(current, paramName);

            if (current.Length < minLength || current.Length > maxLength)
            {
                ThrowException<TException>($"{paramName} should contain between minimum " +
                                           $"{minLength} and max {maxLength} characters.");
            }
        }

        public static void CheckCondition<TException>(bool condition, string conditionDidNotWorkError)
            where TException : BaseDomainException, new()
        {
            if (!condition) ThrowException<TException>(conditionDidNotWorkError);
        }

        private static void ThrowException<TException>(string errorMessage)  
            where TException : BaseDomainException, new()
        {
            throw new TException { Error = errorMessage };
        }
    }
}
