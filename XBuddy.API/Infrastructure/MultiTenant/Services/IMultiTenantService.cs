namespace XBuddy.API.Infrastructure.MultiTenant.Services;

public interface IMultiTenantService
{
    public string GetCurrentTenantId();
    public string SetCurrentTenantId(string tenantId);
    public Guid? GetUserId();
}