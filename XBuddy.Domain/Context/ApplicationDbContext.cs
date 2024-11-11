using Microsoft.EntityFrameworkCore;
using XBuddy.Domain.Entities;
using XBuddy.Domain.Entities.Log;

namespace XBuddy.Domain.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Follow> Follows { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<TenantMapping> TenantMappings { get; set; }
    public DbSet<Tweet> Tweets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
}