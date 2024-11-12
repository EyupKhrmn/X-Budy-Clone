using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using XBuddy.Infrastructure.SqlServer.Context;
using XBuddy.Share.Helpers;

namespace XBuddy.Infrastructure.SqlServer.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfraSqlServices(this IServiceCollection services,
        string connectionString, GetTenantIdDelegate getTenantIdDelegate)
    {
        services.AddDbContext<TenantMappingContext>((sp, options) =>
        {
            var logger = sp.GetRequiredService<ILogger<TenantMappingContext>>();
            options.UseSqlServer(connectionString);
        });

        services.AddDbContext<XBuddyDbContext>((sp, options) =>
        {
            var logger = sp.GetRequiredService<ILogger<XBuddyDbContext>>();
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging(true);
        });

        services.AddSingleton(getTenantIdDelegate);
        return services;
    }
}