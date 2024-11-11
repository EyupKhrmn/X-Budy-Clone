using XBuddy.Domain.Entities.Base;

namespace XBuddy.Domain.Entities.Log;

public class AuditLog : BaseEntity
{
    public User User { get; set; }
    public string TableName { get; set; }
    public string Operation { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
}