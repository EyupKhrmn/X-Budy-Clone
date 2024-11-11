using System.ComponentModel.DataAnnotations.Schema;
using XBuddy.Domain.Entities.Base;

namespace XBuddy.Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public TenantMapping TenantMapping { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Tweet> Tweets { get; set; }
    
    [InverseProperty(nameof(Follow.FollowingUser))]
    public ICollection<Follow> Followings { get; set; }
    
    [InverseProperty(nameof(Follow.FollowerUser))]
    public ICollection<Follow> Followers { get; set; }
}