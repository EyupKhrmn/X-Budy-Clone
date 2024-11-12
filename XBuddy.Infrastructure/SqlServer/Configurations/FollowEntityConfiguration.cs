using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBuddy.Domain.Entities;

namespace XBuddy.Infrastructure.SqlServer.Configurations;

public class FollowEntityConfiguration : BaseEntityConfiguration<Follow>
{
    public new void Configure(EntityTypeBuilder<Follow> builder)
    {
        base.Configure(builder);
    }
}