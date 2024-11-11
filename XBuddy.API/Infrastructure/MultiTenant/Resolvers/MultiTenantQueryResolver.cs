namespace XBuddy.API.Infrastructure.MultiTenant.Resolvers;

public class MultiTenantQueryResolver(IHttpContextAccessor accessor) : IMultiTenantResolver
{
    public string Resolve()
    {
        return accessor.HttpContext
            .Request
            .Query[IMultiTenantResolver.TenantKey]
            .ToString();
    }
}