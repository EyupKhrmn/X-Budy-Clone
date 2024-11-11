using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XBuddy.Domain.Context;

namespace XBuddy.Domain;

public static class ServiceRegistration
{
    public static void AddDomain(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(ts =>
        {
            ts.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
    }
}