using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
