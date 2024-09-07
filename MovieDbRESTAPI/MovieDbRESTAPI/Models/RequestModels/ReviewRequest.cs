using System.ComponentModel.DataAnnotations;

namespace IMDbRESTAPI.Models.RequestModels
{
    public class ReviewRequest
    {

        [Required(ErrorMessage = "Please Add Message Property")]
        public string Message { get; set; }
    }
}
