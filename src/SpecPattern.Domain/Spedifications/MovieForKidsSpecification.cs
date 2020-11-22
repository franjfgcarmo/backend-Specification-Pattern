using SpecPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SpecPattern.Domain.Spedifications
{
    public sealed class MovieForKidsSpecification : Specification<Movie>
    {
        public override Expression<Func<Movie, bool>> ToExpresion()
        {
            return movie => movie.MpaaRating <= MpaaRating.PG;            
        }
    }
}
