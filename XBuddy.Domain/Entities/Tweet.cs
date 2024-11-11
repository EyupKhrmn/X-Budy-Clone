using XBuddy.Domain.Entities.Base;

namespace XBuddy.Domain.Entities;

public class Tweet : BaseEntity
{
    public string Content { get; set; }
    public int LikeCount { get; set; }
    public int ViewCount { get; set; }
    public User User { get; set; }
}