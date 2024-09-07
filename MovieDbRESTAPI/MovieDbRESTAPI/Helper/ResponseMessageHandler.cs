using IMDbRESTAPI.Models.ResponseModels.HTTPMessageResponses;

namespace IMDbRESTAPI.Helper
{
    public class ResponseMessageHandler
    {
        public static SuccessObject SuccessObject(int data, string message)
        {
            return new SuccessObject()
            {
                Data = data,
                Message = message
            };
        }

        public static ErrorObject ErrorObject(string message)
        {
            return new ErrorObject()
            {
                Message = message
            };
        }
    }
}
