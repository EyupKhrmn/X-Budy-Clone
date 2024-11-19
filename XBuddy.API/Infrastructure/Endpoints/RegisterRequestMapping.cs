using XBuddy.API.Infrastructure.Endpoints.RequestHandlers;

namespace XBuddy.API.Infrastructure.Endpoints;

public static class RegisterRequestMapping
{
    public static void RegisterMappings(this WebApplication app)
    {
        FeedEndpoints.RegisterFeedMappings(app);
    }
}