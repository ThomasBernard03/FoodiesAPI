using Foodies.DataAccess;
using Foodies.Domain;
using Microsoft.EntityFrameworkCore;

namespace Foodies.Middlewares;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    
    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context, FoodiesDbContext dbContext)
    {
        var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        if (authHeader != null && authHeader.StartsWith("Bearer"))
        {
            var providedToken = authHeader.Substring("Bearer".Length).Trim();
            if (dbContext.Set<ApiKey>().Any(a => a.Value == providedToken))
            {
                await _next.Invoke(context);
                return;
            }
        }

        context.Response.StatusCode = 401; // Unauthorized
    }
}