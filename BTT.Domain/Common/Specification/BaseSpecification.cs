using System;
using System.Linq.Expressions;

namespace BTT.Domain.Common.Specification
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        private Func<T, bool> compiledExpression;

        private Func<T, bool> CompiledExpression => compiledExpression ??
            (compiledExpression = SpecExpression.Compile());

        public abstract Expression<Func<T, bool>> SpecExpression { get; }

        public bool IsSatisfiedBy(T obj) => CompiledExpression(obj);
    }
}