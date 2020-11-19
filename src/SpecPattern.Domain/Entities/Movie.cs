using System;
using System.Collections.Generic;
using System.Text;

namespace SpecPattern.Domain.Entities
{
    public class Movie:BaseEntity
    {
        /*
         * What we´ve done is we have duplicated the domain knowledge and that violated the don´t repeat yourseft principle.
         */
        public virtual string Name { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual MpaaRating MpaaRating { get; set; }
        public virtual string Genre { get; set; }
        public virtual double Rating { get; set; }
        public virtual bool IsSuitableForChildren() 
        {
            return MpaaRating <= MpaaRating.PG;
        }
        public virtual bool HasCdVersion()
        {
            return ReleaseDate<= DateTime.Now.AddMonths(-1)
 }
    }
}
