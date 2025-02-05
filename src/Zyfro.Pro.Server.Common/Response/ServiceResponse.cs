namespace Zyfro.Pro.Server.Common.Response
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }

        public static ServiceResponse<T> SuccessResponse(T data, string message = "Success", int statusCode = 200)
        {
            return new ServiceResponse<T> { Success = true, Message = message, StatusCode = statusCode, Data = data };
        }

        public static ServiceResponse<T> ErrorResponse(string message, int statusCode = 400)
        {
            return new ServiceResponse<T> { Success = false, Message = message, StatusCode = statusCode };
        }
        public static ServiceResponse<T> InternalErrorResponse(string message, int statusCode = 500)
        {
            return new ServiceResponse<T> { Success = false, Message = message, StatusCode = statusCode };
        }
        public static ServiceResponse<T> NotFoundErrorResponse(string message, int statusCode = 404)
        {
            return new ServiceResponse<T> { Success = false, Message = message, StatusCode = statusCode };
        }
    }
}
