using Newtonsoft.Json.Serialization;
using XBuddy.Application.Repositories;
using XBuddy.Application.Services;
using XBuddy.Infrastructure.CosmosCache.Models;

namespace XBuddy.Infrastructure.CosmosCache.Services;

public class TenantCacheService(ICacheRepository cacheRepository) : ITenantCacheService
{
    public async Task SetCache<T>(string tenantId, string key, T item)
    {
        BaseCosmosModel<T> cacheModel = new()
        {
            Id = key,
            TenantId = tenantId,
            Item = item
        };

        await cacheRepository.Upsert(cacheModel, tenantId);
    }

    public async Task<T> GetCache<T>(string tenantId, string key)
    {
        var cacheModel = await cacheRepository.GetItemById<BaseCosmosModel<T>>(key, tenantId);
        return cacheModel is null ? default(T) : cacheModel.Item;
    }
}