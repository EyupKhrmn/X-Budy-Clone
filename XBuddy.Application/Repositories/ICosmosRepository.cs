using Microsoft.Azure.Cosmos;

namespace XBuddy.Application.Repositories;

public interface ICosmosRepository
{
    Task<ItemResponse<T>> Upsert<T>(T item, string tenantId, CancellationToken cancellationToken = default);

    Task<ItemResponse<T>> Delete<T>(string id, string tenantId);

    Task<T> GetItemById<T>(string id, string tenantId);
}