namespace XBuddy.API.Infrastructure.Services;

public interface ITenantMappingService
{ 
    public Guid? GetUserByTenantId(string tenantId);
}