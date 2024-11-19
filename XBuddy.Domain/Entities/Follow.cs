using XBuddy.Domain.Entities.Base;

namespace XBuddy.Domain.Entities;

public class Follow : BaseEntity
{
    public Guid followerUserId { get; set; }
    public User FollowerUser { get; set; }

    public Guid FollowingUserId { get; set; }
    public User FollowingUser { get; set; }
}