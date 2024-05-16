using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

public class ClaimsAuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public ClaimsAuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var claimsIdentity = context.User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var userClaims = claimsIdentity.Claims.ToList();
                context.Items["UserClaims"] = userClaims;
            }
        }

        await _next(context);
    }
}

public static class ClaimsAuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseClaimsAuthorizationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ClaimsAuthorizationMiddleware>();
    }
}
