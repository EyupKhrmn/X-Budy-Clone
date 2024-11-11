namespace XBuddy.API.Infrastructure.MultiTenant.Resolvers;

public class MultiTenantCookieResolver(IHttpContextAccessor accessor) : IMultiTenantResolver
{
    public string Resolve()
    {
        return accessor.HttpContext
            .Request?
            .Cookies[IMultiTenantResolver.TenantKey]?
            .ToString();
    }
}