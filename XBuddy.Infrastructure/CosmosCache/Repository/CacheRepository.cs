using Microsoft.Azure.Cosmos;
using XBuddy.Application.Repositories;
using XBuddy.Share.Constants;

namespace XBuddy.Infrastructure.CosmosCache.Repository;

public class CacheRepository(CosmosClient cosmosClient) : BaseCosmosRepository(cosmosClient,
    Constants.CosmosConstants.CacheDbName, Constants.CosmosConstants.FeedCacheContainerName) , ICacheRepository
{
    
}