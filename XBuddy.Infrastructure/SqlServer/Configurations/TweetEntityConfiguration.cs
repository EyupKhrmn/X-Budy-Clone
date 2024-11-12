using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBuddy.Domain.Entities;

namespace XBuddy.Infrastructure.SqlServer.Configurations;

public class TweetEntityConfiguration : BaseEntityConfiguration<Tweet>
{
    public new void Configure(EntityTypeBuilder<Tweet> builder)
    {
        base.Configure(builder);
    }
}