using System;

namespace SpecPattern.Api.EndPoints.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public  DateTime ReleaseDate { get; set; }
        public  string MpaaRating { get; set; }
        public  string Genre { get; set; }
        public  double Rating { get; set; }        
        public string Director { get; set; }
    }
}
