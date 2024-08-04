using Newtonsoft.Json;

namespace Blog.MiddleWares; 


public class ErrorHandlingMiddleware {
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        try {
            await _next(context);
        } catch (Exception ex) {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception) {
        Console.WriteLine($"Exception caught: {exception}");
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        var result = JsonConvert.SerializeObject(new { error = exception.Message });
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(result);
    }
}