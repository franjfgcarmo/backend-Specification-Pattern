namespace SpecPattern.Api.EndPoints.Models
{
    public class FilterMovie
    {
        public bool ForKidsOnly { get; set; }
        public double MinimunRating { get; set; }
        public bool OnCd { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}
