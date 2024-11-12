using XBuddy.Infrastructure.SqlServer.Context;

namespace XBuddy.API.Infrastructure.Services;

public class TenantMappingService : ITenantMappingService
{
    private readonly IServiceProvider _serviceProvider;
    private Dictionary<string, Guid> map;


    public TenantMappingService(IServiceProvider serviceProvider, Dictionary<string, Guid> map)
    {
        _serviceProvider = serviceProvider;
        this.map = map;
        LoadMap();
    }

    public Guid? GetUserByTenantId(string tenantId)
    {
        return map.TryGetValue(tenantId, out var userId) ? userId : null;
    }

    private void LoadMap()
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<TenantMappingContext>();
        map = dbContext.TenantMappings.ToDictionary(ts => ts.TenantId, ts => ts.UserId);
    }
}