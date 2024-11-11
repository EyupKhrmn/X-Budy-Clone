namespace XBuddy.API.Infrastructure.MultiTenant.Services;

public class MultiTenantService : IMultiTenantService
{
    private string TenantId;
    public string GetCurrentTenantId() => TenantId;
    public string SetCurrentTenantId(string tenantId) => this.TenantId = tenantId;

    // ToDO GetUserId gelecek
}