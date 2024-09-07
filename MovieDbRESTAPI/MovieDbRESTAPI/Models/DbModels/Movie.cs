namespace IMDbRESTAPI.Models.DbModels
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public int ProducerId { get; set; }
        public string Poster { get; set; }
        public string Language { get; set; }
        public int Profit { get; set; }
    }
}
