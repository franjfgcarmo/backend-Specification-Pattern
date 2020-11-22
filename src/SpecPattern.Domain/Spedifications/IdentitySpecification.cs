using System;
using System.Linq.Expressions;
/*
 * Specifications must actually contain the domain knowledge and not merely except it from the outside worrd.
 */
namespace SpecPattern.Domain.Spedifications
{
    internal sealed class IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}
