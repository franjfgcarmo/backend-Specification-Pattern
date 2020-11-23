using SpecPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SpecPattern.Domain.Spedifications
{
    public class MovieDirectedBySpecification : Specification<Movie>
    {
        private readonly string _director;
        public MovieDirectedBySpecification(string director) {
            _director = director;
        }
        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.Director.Name.Contains(_director);
        }
    }
}
