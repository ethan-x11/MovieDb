using System;
using System.ComponentModel.DataAnnotations;

namespace IMDbRESTAPI.Models.RequestModels
{
    public class ActorRequest
    {
        [Required(ErrorMessage = "Please Add Name Property")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Add Gender Property")]
        [RegularExpression("^[MFOmfo]$")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Add DOB Property")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        public string Bio { get; set; }
    }
}
