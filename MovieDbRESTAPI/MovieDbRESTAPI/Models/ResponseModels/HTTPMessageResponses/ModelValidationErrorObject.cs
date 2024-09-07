using System.Collections.Generic;

namespace IMDbRESTAPI.Models.ResponseModels.HTTPMessageResponses
{
    public class ModelValidationErrorObject
    {
        public string Message { get; set; }
        public List<string> Errors { get; } = new();
    }
}
