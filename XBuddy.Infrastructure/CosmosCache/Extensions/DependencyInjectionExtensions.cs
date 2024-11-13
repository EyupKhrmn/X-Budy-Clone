using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.DependencyInjection;
using XBuddy.Application.Repositories;
using XBuddy.Application.Services;
using XBuddy.Infrastructure.CosmosCache.Repository;
using XBuddy.Infrastructure.CosmosCache.Services;

namespace XBuddy.Infrastructure.CosmosCache.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfraCosmosServices(this IServiceCollection services,string cosmosConnectionString)
    {
        services.AddSingleton(sp =>
        {
            var builder = new CosmosClientBuilder(cosmosConnectionString)
                .WithApplicationName("XBuddyApi")
                .WithSerializerOptions(new CosmosSerializationOptions()
                {
                    Indented = true
                })
                .WithThrottlingRetryOptions(TimeSpan.FromSeconds(5), 10);

            return builder.Build();
        });

        services.AddScoped<ITenantCacheService, TenantCacheService>();
        services.AddScoped<ICacheRepository, CacheRepository>();
        services.AddScoped<ICosmosRepository, BaseCosmosRepository>();

        return services;
    }
}