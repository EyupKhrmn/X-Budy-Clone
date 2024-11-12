using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBuddy.Domain.Entities;

namespace XBuddy.Infrastructure.SqlServer.Configurations;

public class LikeEntityConfiguration : BaseEntityConfiguration<Like>
{
    public new void Configure(EntityTypeBuilder<Like> builder)
    {
        base.Configure(builder);
    }
}