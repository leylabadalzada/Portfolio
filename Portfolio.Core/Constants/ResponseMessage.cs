using Portfolio.Core.Enums;

namespace Portfolio.Core.Constants
{
    public static class ResponseMessage
    {
        public static string FailMessage(ResponseMessageContent content) => $"{content.ToString()} failed";
        public static string SuccessMessage(string content) => $"{content} successfully!";
        public static string NotFoundMessage(string content) => $"{content} not found!";
    }
}
