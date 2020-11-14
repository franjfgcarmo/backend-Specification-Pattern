using System;
using System.Collections.Generic;
using System.Text;

namespace SpecPattern.Domain.Entities
{
    public class Movie:BaseEntity
    {

        public virtual string Name { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual MpaaRating MpaaRating { get; set; }
        public virtual string Genre { get; set; }
        public virtual double Rating { get; set; }        
    }
}
