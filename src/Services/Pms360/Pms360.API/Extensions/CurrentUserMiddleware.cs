using System.Security.Claims;
namespace Pms360.API.Extensions;

public class CurrentUserMiddleware
{
    private readonly RequestDelegate _next;

    public CurrentUserMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context, CurrentUserService currentUser)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            currentUser.EmpCode = context.User.FindFirst("EmpCode")?.Value;

            var userId = context.User.FindFirst("UserId")?.Value
                      ?? context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            currentUser.UserId = userId != null ? Guid.Parse(userId) : Guid.Empty;

            currentUser.email = context.User.FindFirst("email")?.Value
                             ?? context.User.FindFirst(ClaimTypes.Email)?.Value;
        }

        await _next(context);
    }
}
