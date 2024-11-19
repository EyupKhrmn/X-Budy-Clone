namespace XBuddy.Application.Services;

public interface ITenantMappingService
{ 
    public Guid? GetUserByTenantId(string tenantId);
}