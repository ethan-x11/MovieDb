namespace IMDbRESTAPI.Models.RequestModels.FilterRequests
{
    public class MovieFilterRequest
    {
        public int? Year { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public string SortBy { get; set; }
        public string Order { get; set; }
    }
}
