using BTT.Domain.Common.Models;
using BTT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Common.Extensions
{
    public static class ValidationExtensions
    {
        public static void CheckNull(this string data, string paramName = "Value")
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void CheckNull<T>(this T obj, string paramName = "Value") 
            where T : IAggregateRoot, IEntity
        {
            if (obj is null) 
            {
                throw new ArgumentNullException(paramName);
            } 
        }

        public static void ThrowIfConditionNotMet<TException,T>(this T obj, string message, Predicate<T> condition)
            where T : IAggregateRoot, IEntity where TException : BaseDomainException, new() 
        {
            if (condition.Invoke(obj) != true)
            {
                ThrowException<TException>(message);
            } 
        }

        public static void ThrowIfConditionNotMet<TExeption>(this string data, string message, Predicate<string> condition)
            where TExeption : BaseDomainException, new()
        {
            if (condition.Invoke(data) != true)
            {
                ThrowException<TExeption>(message);
            }
        }

        private static void ThrowException<TException>(string errorMessage) 
            where TException : BaseDomainException, new()
        {
            throw new TException { Error = errorMessage };
        }
    }
}
