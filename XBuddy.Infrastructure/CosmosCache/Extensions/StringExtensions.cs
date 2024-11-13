using Microsoft.Azure.Cosmos;

namespace XBuddy.Infrastructure.CosmosCache.Extensions;

internal static class StringExtensions
{
    internal static PartitionKey ToPartitionKey(this string id)
    {
        return new PartitionKey(id);
    }
}