namespace XBuddy.Application.Services;

public interface ITenantCacheService
{
    Task SetCache<T>(string tenantId, string key, T item);
    Task<T> GetCache<T>(string tenantId, string key);
}