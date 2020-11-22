using SpecPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SpecPattern.Domain.Spedifications.Implementations
{
    public sealed class AvailabeOnCDSpecification : Specification<Movie>
    {
        private const int MonthsBeforeDVDIsOut = 12;
        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.ReleaseDate <= DateTime.Now.AddMonths(-MonthsBeforeDVDIsOut);
        }
    }
}
