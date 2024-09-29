namespace KupujemProdajemClone.Middleware;

public class AuthenticationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        var endpoint = httpContext.GetEndpoint();

        if (endpoint?.DisplayName?.Contains("LogIn") ?? false)
        {
            await next(httpContext);
            return;
        }

        if (httpContext.User.Identity is { IsAuthenticated: false })
        {
            httpContext.Response.Redirect($"/Users/LogIn?returnUrl=/");
            return;
        }

        await next(httpContext);
    }
}

public static class AuthenticationMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<AuthenticationMiddleware>();
}