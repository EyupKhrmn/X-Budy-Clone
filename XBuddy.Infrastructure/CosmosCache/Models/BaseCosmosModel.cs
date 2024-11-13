using Newtonsoft.Json;

namespace XBuddy.Infrastructure.CosmosCache.Models;

public record BaseCosmosModel<T>
{
    [JsonProperty("id")]
    public string Id { get; set; } = new Guid().ToString();
    [JsonProperty("tenantId")]
    public string TenantId { get; set; }
    public T Item { get; set; }
}