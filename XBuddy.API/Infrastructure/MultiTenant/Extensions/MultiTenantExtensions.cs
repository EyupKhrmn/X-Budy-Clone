using Microsoft.Extensions.DependencyInjection.Extensions;
using XBuddy.API.Infrastructure.Middleware;
using XBuddy.API.Infrastructure.MultiTenant.Options;
using XBuddy.API.Infrastructure.MultiTenant.Resolvers;
using XBuddy.API.Infrastructure.MultiTenant.Services;
using XBuddy.API.Infrastructure.Services;
using XBuddy.Application.Services;

namespace XBuddy.API.Infrastructure.MultiTenant.Extensions;

public static class MultiTenantExtensions
{
    public static IServiceCollection AddMultiTenancy(this IServiceCollection services,
        Action<MultiTenancyOptions> options)
    {
        services.AddHttpContextAccessor();
        services.AddSingleton<MultiTenantMiddleware>();
        services.AddScoped<IMultiTenantService, MultiTenantService>();
        services.AddSingleton<ITenantMappingService, TenantMappingService>();

        services.AddScoped<MultiTenantIdEndpointFilter>();

        var opt = new MultiTenancyOptions();
        options(opt);

        if (opt.InternalUseCookieResolver)
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantCookieResolver>());
        if (opt.InternalUseHeaderResolver)
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantHeaderResolver>());
        if (opt.InternalUseQueryResolver)
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantQueryResolver>());
        if (opt.InternalUseRouteResolver)
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantUrlRouteResolver>());
        if (!opt.AtLeastOneActive)
            throw new Exception("No MultiTenantResolver Found");

        return services;
    }

    public static IServiceCollection AddMultiTenancy(this IServiceCollection services)
    {
        AddMultiTenancy(services, opt =>
        {
            opt.UseRouteResolver()
                .UseQueryResolver()
                .UseHeaderResolver()
                .UseCookieResolver();
        });

        return services;
    }

    public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder app)
    {
        app.UseMiddleware<MultiTenantMiddleware>();

        return app;
    }
}