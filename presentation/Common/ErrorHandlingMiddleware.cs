using System.ComponentModel.DataAnnotations;
using System.Net;
using Newtonsoft.Json;

namespace presentation.Common;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    public class ErrorMessage
    { 
        public string Message { get; set; }
    }
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = new ErrorMessage();

        if (exception is ValidationException ex)
        {
                
            if (!string.IsNullOrWhiteSpace(ex.Message))
            {
                result = new ErrorMessage
                {
                    Message = string.Join(" ", ex.Message.Split("_"))
                };
            }
            code = HttpStatusCode.BadRequest;
        }
        else
        {
            result = new ErrorMessage
            {
                Message = "Oops... Something went wrong. Contact support to resolve this."
            };
        }
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
    }
}
public static class ErrorHandlingMiddlewareExtensions
{
    public static void UseGenericErrorHandling(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}