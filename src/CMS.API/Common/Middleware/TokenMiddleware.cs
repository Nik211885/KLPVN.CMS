namespace CMS.API.Common.Middleware;

public class TokenMiddleware : IMiddleware
{
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    if (context.Request.Cookies.TryGetValue("Token", out var token))
    {
      context.Request.Headers.Authorization = "Bearer " + token;
    }
    await next(context);
  }
}
