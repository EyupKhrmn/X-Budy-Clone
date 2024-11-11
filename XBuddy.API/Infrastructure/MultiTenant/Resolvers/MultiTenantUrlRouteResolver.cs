namespace XBuddy.API.Infrastructure.MultiTenant.Resolvers;

public class MultiTenantUrlRouteResolver(IHttpContextAccessor accessor) : IMultiTenantResolver
{
    public string Resolve()
    {
        return accessor.HttpContext
            .Request?
            .RouteValues[IMultiTenantResolver.TenantKey]?
            .ToString();
    }
}