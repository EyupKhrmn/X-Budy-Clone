using XBuddy.API.Infrastructure.Services;

namespace XBuddy.API.Infrastructure.MultiTenant.Services;

public class MultiTenantService : IMultiTenantService
{
    private string TenantId;
    private readonly ITenantMappingService _tenantMappingService;

    public MultiTenantService(ITenantMappingService tenantMappingService)
    {
        _tenantMappingService = tenantMappingService;
    }

    public string GetCurrentTenantId() => TenantId;
    public string SetCurrentTenantId(string tenantId) => this.TenantId = tenantId;

    public Guid? GetUserId() => _tenantMappingService.GetUserByTenantId(TenantId);
}