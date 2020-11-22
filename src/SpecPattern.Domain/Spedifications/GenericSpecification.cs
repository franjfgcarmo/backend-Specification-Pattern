using System;
using System.Linq.Expressions;

namespace SpecPattern.Domain.Spedifications
{
    public class GenericSpecification<T>
    {
        public Expression<Func<T, bool>> Expression { get; }

        public GenericSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public bool IsSatisFiedBy(T entity)
        {
            return Expression.Compile().Invoke(entity);
        }
    }
}
