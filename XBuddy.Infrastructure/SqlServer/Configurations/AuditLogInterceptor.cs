using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using XBuddy.Domain.Entities.Log;

namespace XBuddy.Infrastructure.SqlServer.Configurations;

public class AuditLogInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = eventData.Context.ChangeTracker.Entries().ToList();
        var auditLogs = eventData.Context.ChangeTracker.Entries()
            .Where(ts => ts.Entity is not AuditLog)
            .Where(ts => ts.State == EntityState.Added || ts.State == EntityState.Deleted ||
                         ts.State == EntityState.Modified);

        var auditLogEntities = new List<AuditLog>();
        foreach (var auditLog in auditLogs)
        {
            var log = new AuditLog
            {
                TableName = auditLog.Metadata.GetTableName(),
                Operation = auditLog.State.ToString(),
                CreatedDate = DateTime.Now
            };

            if (auditLog.State == EntityState.Modified)
            {
                log.OldValue = JsonSerializer.Serialize(
                    auditLog.OriginalValues.Properties.ToDictionary(ts => ts.Name, ts => auditLog.OriginalValues[ts]));
                log.NewValue = JsonSerializer.Serialize(
                    auditLog.CurrentValues.Properties.ToDictionary(ts => ts.Name, ts => auditLog.CurrentValues[ts]));
            }
            else if (auditLog.State == EntityState.Added)
            {
                log.NewValue = JsonSerializer.Serialize(
                    auditLog.CurrentValues.Properties.ToDictionary(ts => ts.Name, ts => auditLog.CurrentValues[ts]));
            }
            else if (auditLog.State == EntityState.Deleted)
            {
                log.OldValue = JsonSerializer.Serialize(
                    auditLog.OriginalValues.Properties.ToDictionary(ts => ts.Name, ts => auditLog.OriginalValues[ts]));
            }
            
            auditLogEntities.Add(log);
        }
        
        eventData.Context.Set<AuditLog>().AddRange(auditLogEntities);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}