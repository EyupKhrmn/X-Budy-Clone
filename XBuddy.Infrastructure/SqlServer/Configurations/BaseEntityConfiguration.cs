using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBuddy.Domain.Entities.Base;

namespace XBuddy.Infrastructure.SqlServer.Configurations;

public abstract class BaseEntityConfiguration<TBaseEntity> : IEntityTypeConfiguration<TBaseEntity> where TBaseEntity : BaseEntity
{
    public void Configure(EntityTypeBuilder<TBaseEntity> builder)
    {
        builder.HasKey(ts => ts.Id);
        builder.Property(ts => ts.Id).ValueGeneratedOnAdd().HasDefaultValueSql("newsequentialid()");
        builder.Property(ts => ts.CreatedDate).IsRequired();
        builder.Property(ts => ts.ModifiedDate).IsRequired(false);
    }
}