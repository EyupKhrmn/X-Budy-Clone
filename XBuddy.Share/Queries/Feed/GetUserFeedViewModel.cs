namespace XBuddy.Share.Queries.Feed;

public class GetUserFeedViewModel
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public int LikeCount { get; set; }
    public bool IsLiked { get; set; }
    public int ViewCount { get; set; }
    public DateTime CreatedDate { get; set; }
}