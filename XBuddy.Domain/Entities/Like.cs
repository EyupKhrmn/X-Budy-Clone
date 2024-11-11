using XBuddy.Domain.Entities.Base;

namespace XBuddy.Domain.Entities;

public class Like : BaseEntity
{
    public User User { get; set; }
    public Tweet Tweet { get; set; }
}