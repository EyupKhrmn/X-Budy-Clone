using XBuddy.Domain.Entities.Base;

namespace XBuddy.Domain.Entities;

public class Follow : BaseEntity
{
    public int followerUserId { get; set; }
    public User FollowerUser { get; set; }

    public int FollowingUserId { get; set; }
    public User FollowingUser { get; set; }
}