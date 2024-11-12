using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBuddy.Domain.Entities;

namespace XBuddy.Infrastructure.SqlServer.Configurations;

public class UserEntityConfiguration : BaseEntityConfiguration<User>
{
    public new void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
    }
}