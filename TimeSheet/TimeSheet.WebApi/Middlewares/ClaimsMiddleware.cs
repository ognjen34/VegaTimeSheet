using System.Security.Claims;

namespace TimeSheet.WebApi.Middlewares
{
    public class ClaimsMiddleware
    {
        private readonly RequestDelegate _next;

        public ClaimsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.User.Identity is ClaimsIdentity identity)
            {
                try
                {
                    context.Items["UserId"] = Guid.Parse(identity.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                    context.Items["UserName"] = identity.FindFirst(ClaimTypes.Name)?.Value;
                    context.Items["UserEmail"] = identity.FindFirst(ClaimTypes.Email)?.Value;
                    context.Items["UserRole"] = identity.FindFirst(ClaimTypes.Role)?.Value;
                }
                catch {
                }
            }

            await _next(context);
        }

    }
}
