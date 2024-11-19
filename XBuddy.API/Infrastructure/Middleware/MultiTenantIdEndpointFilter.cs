using XBuddy.API.Infrastructure.MultiTenant.Services;
using XBuddy.Application.Infrastructure.Models.MultiTenant;

namespace XBuddy.API.Infrastructure.Middleware;

public class MultiTenantIdEndpointFilter(IMultiTenantService multiTenantService) : IEndpointFilter
{
    public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var currentTenantId = multiTenantService.GetCurrentTenantId();

        foreach (var arg in context.Arguments)
        {
            if (arg is IMultiTenant multiTenantArg)
            {
                multiTenantArg.TenantId = currentTenantId;
            }
        }

        return await next(context);
    }
}