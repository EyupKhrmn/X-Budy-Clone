namespace XBuddy.API.Infrastructure.MultiTenant.Resolvers;

public class MultiTenantHeaderResolver(IHttpContextAccessor accessor) : IMultiTenantResolver
{
    public string Resolve()
    {
        return accessor.HttpContext
            .Request
            .Headers[IMultiTenantResolver.TenantKey]
            .ToString();
    }
}