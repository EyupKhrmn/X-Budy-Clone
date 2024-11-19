using XBuddy.Domain.Entities.Base;

namespace XBuddy.Domain.Entities;

public class Tweet : BaseEntity
{
    public string Content { get; set; }
    public int LikeCount { get; set; }
    public int ViewCount { get; set; }
    public bool IsLike { get; set; }
    public List<Like> Likes { get; set; }
    public string UserName { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}