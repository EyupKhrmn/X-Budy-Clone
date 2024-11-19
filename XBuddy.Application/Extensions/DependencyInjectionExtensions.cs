using Mapster;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.Extensions.DependencyInjection;

namespace XBuddy.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMapster();
        
        return services;
    }
}