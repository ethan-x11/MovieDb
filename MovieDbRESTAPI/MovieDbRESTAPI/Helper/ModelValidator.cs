using IMDbRESTAPI.Models.ResponseModels.HTTPMessageResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace IMDbRESTAPI.Helper
{
    public class ModelValidator
    {
        public static IActionResult GenerateErrorResponse(ActionContext context)
        {
            var apiError = new ModelValidationErrorObject
            {
                Message = "Validation Error!",
            };

            var errors = context.ModelState.AsEnumerable();

            foreach (var error in errors)
            {
                foreach (var subError in error.Value!.Errors)
                {
                    apiError.Errors.Add(subError.ErrorMessage);
                }
            }

            return new BadRequestObjectResult(apiError);

        }
    }
}
