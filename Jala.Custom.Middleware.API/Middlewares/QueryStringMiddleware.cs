using System.Security.Cryptography.X509Certificates;

namespace Jala.Custom.Middleware.API.Middlewares;

public class QueryStringMiddleware
{
    private readonly RequestDelegate _next;

    public QueryStringMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        ParamHandler(context);
        await _next(context);
    }

    public void ParamHandler(HttpContext context)
    {
        if (context.Request.Query.ContainsKey("name"))
        {
            Console.WriteLine(context.Request.Query["name"]);
        }
    }
}

public static class QueryStringMiddlewareClass
{
    public static IApplicationBuilder UseQueryStringMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<QueryStringMiddleware>();
    }
}
