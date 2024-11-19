using Mediator;
using Microsoft.EntityFrameworkCore;
using XBuddy.Application.Infrastructure.Models.MultiTenant;
using XBuddy.Application.Services;
using XBuddy.Domain.Context;
using XBuddy.Share.Queries.Feed;

namespace XBuddy.Application.Features.Feed.Queries;

public class GetUserFeedQuery : IRequest<List<GetUserFeedViewModel>>, IMultiTenant
{
    public string TenantId { get; set; }
    
    public class GetUserFeedQueryHandler(ITenantMappingService tenantMappingService, ApplicationDbContext context)
        : IRequestHandler<GetUserFeedQuery, List<GetUserFeedViewModel>>
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ITenantMappingService _tenantMappingService = tenantMappingService;

        public async ValueTask<List<GetUserFeedViewModel>> Handle(GetUserFeedQuery request, CancellationToken cancellationToken)
        {
            var tenantUserId = _tenantMappingService.GetUserByTenantId(request.TenantId);

            var feed = await _context.Follows.Where(ts => ts.followerUserId == tenantUserId)
                .SelectMany(ts => ts.FollowingUser.Tweets)
                .OrderByDescending(ts => ts.CreatedDate)
                .Select(ts => new GetUserFeedViewModel
                {
                    Id = ts.Id,
                    Content = ts.Content,
                    CreatedDate = ts.CreatedDate,
                    LikeCount = ts.LikeCount,
                    UserId = ts.UserId,
                    UserName = ts.UserName,
                    IsLiked = ts.Likes.Any(ts => ts.User.Id == tenantUserId)
                }).ToListAsync(cancellationToken: cancellationToken);

            return feed;
        }
    }
}