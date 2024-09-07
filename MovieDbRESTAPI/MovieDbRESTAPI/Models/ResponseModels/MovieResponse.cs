using System.Collections.Generic;

namespace IMDbRESTAPI.Models.ResponseModels
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public ProducerResponse Producer { get; set; }
        public string Poster { get; set; }
        public string Language { get; set; }
        public int Profit { get; set; }
        public IEnumerable<ActorResponse> Actors { get; set; }
        public IEnumerable<GenreResponse> Genres { get; set; }

    }
}
