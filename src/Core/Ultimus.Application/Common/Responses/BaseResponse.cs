namespace Ultimus.Application.Common.Responses
{
    public class BaseResponse
    {
        public BaseResponse() { 
            Success  = true;
            Message = "Success";
        }
        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }


        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string>? ValidationErrors { get; set; }
    }
}
