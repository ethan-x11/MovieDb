using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDbRESTAPI.Models.RequestModels
{
    public class MovieRequest
    {
        [Required(ErrorMessage = "Please Add Title Property")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Add YearOfRelease Property")]
        public int YearOfRelease { get; set; }

        public string Plot { get; set; }

        [Required(ErrorMessage = "Please Add ProducerId Property")]
        public int ProducerId { get; set; }

        public string Poster { get; set; }

        [Required(ErrorMessage = "Please Add Language Property")]
        public string Language { get; set; }

        public int Profit { get; set; }

        public IEnumerable<int> ActorIds { get; set; }

        public IEnumerable<int> GenreIds { get; set; }

    }
}
