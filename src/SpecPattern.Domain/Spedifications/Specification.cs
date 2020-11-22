using System;
using System.Linq.Expressions;
/*
 * Specifications must actually contain the domain knowledge and not merely except it from the outside worrd.
 */
namespace SpecPattern.Domain.Spedifications
{
    public abstract class Specification<T>
    {
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpresion().Compile();
            return predicate(entity);
        }


        public abstract Expression<Func<T, bool>> ToExpresion();
    }
}
