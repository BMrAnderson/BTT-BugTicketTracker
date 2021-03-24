using System;
using System.Linq.Expressions;

namespace BTT.Domain.Common.Specification
{
    public class OrSpecification<T> : BaseSpecification<T>
    {
        private ISpecification<T> leftSpec;
        private ISpecification<T> rightSpec;

        public OrSpecification(ISpecification<T> leftSpec, ISpecification<T> rightSpec)
        {
            this.leftSpec = leftSpec;
            this.rightSpec = rightSpec;
        }

        public override Expression<Func<T, bool>> SpecExpression
        {
            get
            {
                var paramObj = Expression.Parameter(typeof(T), "obj");

                var exprResult = Expression.Lambda<Func<T, bool>>(
                    Expression
                    .OrElse(
                        Expression.Invoke(leftSpec.SpecExpression, paramObj),
                        Expression.Invoke(rightSpec.SpecExpression, paramObj)), paramObj
                        );
                return exprResult;
            }
        }
    }
}