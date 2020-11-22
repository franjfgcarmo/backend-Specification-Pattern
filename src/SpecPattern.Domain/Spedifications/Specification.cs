using System;
using System.Linq.Expressions;
/*
 * Specifications must actually contain the domain knowledge and not merely except it from the outside worrd.
 */
namespace SpecPattern.Domain.Spedifications
{
    public abstract class Specification<T>
    {
        //This specs will result in generating additional Where statement in Sql queries (1=1)
        public static readonly Specification<T> All = new IdentitySpecification<T>();
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }
        public Specification<T> And(Specification<T> specification)
        {
            if (this == All)
                return specification;
            if (specification == All)
                return this;

            return new AndSpecification<T>(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            return this == All || specification == All ? All : new OrSpecification<T>(this, specification);
        }

        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        public abstract Expression<Func<T, bool>> ToExpression();
    }
}
