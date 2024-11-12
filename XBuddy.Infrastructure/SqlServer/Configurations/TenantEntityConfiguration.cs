using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBuddy.Domain.Entities;

namespace XBuddy.Infrastructure.SqlServer.Configurations;

public class TenantEntityConfiguration : BaseEntityConfiguration<TenantMapping>
{
    public new void Configure(EntityTypeBuilder<TenantMapping> builder)
    {
        base.Configure(builder);
    }
}