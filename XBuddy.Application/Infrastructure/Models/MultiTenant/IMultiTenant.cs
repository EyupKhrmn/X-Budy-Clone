namespace XBuddy.Application.Infrastructure.Models.MultiTenant;

public interface IMultiTenant
{
    public string TenantId { get; set; }
}