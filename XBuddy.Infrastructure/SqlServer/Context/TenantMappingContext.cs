using Microsoft.EntityFrameworkCore;
using XBuddy.Domain.Entities;
using XBuddy.Infrastructure.SqlServer.Configurations;

namespace XBuddy.Infrastructure.SqlServer.Context;

public class TenantMappingContext(DbContextOptions<TenantMappingContext> options) : DbContext(options)
{
    public DbSet<TenantMapping> TenantMappings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("xb");
        modelBuilder.ApplyConfiguration(new TenantEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}