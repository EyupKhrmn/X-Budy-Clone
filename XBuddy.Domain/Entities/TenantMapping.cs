using XBuddy.Domain.Entities.Base;

namespace XBuddy.Domain.Entities;

public class TenantMapping : BaseEntity
{
    public string TenantId { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}