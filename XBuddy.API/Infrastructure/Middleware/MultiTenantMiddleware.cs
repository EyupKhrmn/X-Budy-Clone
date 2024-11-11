using Microsoft.IdentityModel.Tokens;
using XBuddy.API.Infrastructure.MultiTenant.Resolvers;
using XBuddy.API.Infrastructure.MultiTenant.Services;

namespace XBuddy.API.Infrastructure.Middleware;

public class MultiTenantMiddleware(IEnumerable<IMultiTenantResolver> resolvers) : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var multiTenantService = context.RequestServices.GetRequiredService<IMultiTenantService>();
        
        foreach (var resolver in resolvers)
        {
            var tenantId = resolver.Resolve();
            if(tenantId.IsNullOrEmpty())
                continue;

            multiTenantService.SetCurrentTenantId(tenantId);

            return next(context);
        }

        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        return context.Response.WriteAsync("No tenant found");
    }
}