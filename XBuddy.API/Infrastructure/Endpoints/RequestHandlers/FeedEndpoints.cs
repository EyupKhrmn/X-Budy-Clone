using Mediator;
using Microsoft.AspNetCore.Mvc;
using XBuddy.API.Infrastructure.Middleware;
using XBuddy.API.Infrastructure.MultiTenant.Services;
using XBuddy.Application.Features.Feed.Queries;
using XBuddy.Share.Helpers;

namespace XBuddy.API.Infrastructure.Endpoints.RequestHandlers;

public static class FeedEndpoints
{
    public static void RegisterFeedMappings(this WebApplication app)
    {
        app.MapGet("feed".AdjustTenantRoute(), HandleFeed).AddEndpointFilter<MultiTenantIdEndpointFilter>();
    }

    private static async Task<IResult> HandleFeed(HttpContext context, [FromServices] IMediator mediator, [AsParameters] GetUserFeedQuery query)
    {
        var response = await mediator.Send(query);
        
        return Results.Ok(response);
    }
}