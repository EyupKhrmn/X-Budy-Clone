
using XBuddy.Share.Constants;

namespace XBuddy.API.Infrastructure.MultiTenant.Resolvers;

public interface IMultiTenantResolver
{
    public static string TenantKey => Constants.MultiTenantConstants.TenantId;

    string Resolve();
}