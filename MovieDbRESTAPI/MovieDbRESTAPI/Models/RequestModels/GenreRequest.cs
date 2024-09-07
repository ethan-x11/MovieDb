using System.ComponentModel.DataAnnotations;

namespace IMDbRESTAPI.Models.RequestModels
{
    public class GenreRequest
    {
        [Required(ErrorMessage = "Please Add Name Property")]
        public string Name { get; set; }
    }
}
