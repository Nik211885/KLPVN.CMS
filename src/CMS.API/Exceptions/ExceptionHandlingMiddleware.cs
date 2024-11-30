using KLPVN.Core.Models;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace CMS.API.Exceptions;

public class ExceptionHandlingMiddleware : IMiddleware
{
  private readonly ILogger<ExceptionHandlingMiddleware> _logger;

  public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
  {
    _logger = logger;
  }
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    try
    {
      await next(context);
    }
    catch (Exception ex)
    {
      await HandlerExceptionAsync(context, ex);
    }
  }

  private async Task HandlerExceptionAsync(HttpContext context, Exception ex)
  {
    int statusCode = GetStatusCode(ex);
    if (statusCode >= 500)
    {
      var controllerName = context.GetRouteData()?.Values["controller"]?.ToString();
      var actionName = context.GetRouteData()?.Values["action"]?.ToString();
      var requestMethod = context.Request.Method;
      var requestPath = context.Request.Path;
      var time = DateTimeOffset.UtcNow.AddHours(7);
      _logger.LogError(ex, "{Time} - Exception occurred at {Controller}/{Action} - Path: {Path}, Method: {Method}",
        time, controllerName, actionName, requestPath, requestMethod);
    }
    var response = new ErrorResponse(
      "An error occurred", 
      statusCode, 
      statusCode >=500 ? "Có lỗi server" : ex.Message);
    context.Response.ContentType = "application/json";
    context.Response.StatusCode = statusCode;
    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
  }

  private int GetStatusCode(Exception exception)
  {
    return exception switch
    {
      NotFoundException => StatusCodes.Status404NotFound,
      BadRequestException => StatusCodes.Status400BadRequest,
      UnauthorizedException => StatusCodes.Status401Unauthorized,
      _ => StatusCodes.Status500InternalServerError
    };
  }
}
