using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using XBuddy.Application.Repositories;
using XBuddy.Infrastructure.CosmosCache.Extensions;

namespace XBuddy.Infrastructure.CosmosCache.Repository;

public class BaseCosmosRepository(CosmosClient cosmosClient,string dbName,string containerName) : ICosmosRepository
{
    private readonly Container _container = cosmosClient.GetContainer(dbName, containerName);

    public virtual async Task<ItemResponse<T>> Upsert<T>(T item, string tenantId,
        CancellationToken cancellationToken = default)
    {
        return await _container.UpsertItemAsync(item, tenantId.ToPartitionKey(), cancellationToken: cancellationToken);
    }

    public virtual async Task<ItemResponse<T>> Delete<T>(string id, string tenantId)
    {
        return await _container.DeleteItemAsync<T>(id, tenantId.ToPartitionKey());
    }

    public virtual async Task<T> GetItemById<T>(string id, string tenantId)
    {
        using var streamResponse = await _container.ReadItemStreamAsync(id, tenantId.ToPartitionKey());

        if (!streamResponse.IsSuccessStatusCode)
        {
            var cacheModel = cosmosClient.ClientOptions.Serializer.FromStream<T>(streamResponse.Content);
            return cacheModel;
        }
        return default;
    }
}