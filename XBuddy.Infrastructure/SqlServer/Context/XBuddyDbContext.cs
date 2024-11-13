using Microsoft.EntityFrameworkCore;
using XBuddy.Domain.Entities;
using XBuddy.Domain.Entities.Base;
using XBuddy.Domain.Entities.Log;
using XBuddy.Infrastructure.SqlServer.Configurations;
using XBuddy.Share.Helpers;

namespace XBuddy.Infrastructure.SqlServer.Context;

public class XBuddyDbContext(DbContextOptions<XBuddyDbContext> options,
    GetTenantIdDelegate getTenantIdDelegate,
    IServiceProvider serviceProvider) : DbContext(options)
{
    public DbSet<Follow> Follows { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Tweet> Tweets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("xb");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityConfiguration<>).Assembly);

        var userId = Guid.Parse(getTenantIdDelegate(serviceProvider));
        modelBuilder.Entity<User>().HasQueryFilter(ts => ts.Id == userId);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditLogInterceptor());
        base.OnConfiguring(optionsBuilder);
    }
}