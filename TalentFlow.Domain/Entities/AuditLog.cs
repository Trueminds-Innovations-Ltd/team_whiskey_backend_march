using System.ComponentModel.DataAnnotations.Schema;
using TalentFlow.Domain.Common;

namespace TalentFlow.Domain.Entities
{
    [Table("auditLogs")] // matches EF query
    public class AuditLog : EntityBase
    {
        public Guid Id { get; private set; }

        public string EntityName { get; private set; } = null!; // ✅ FIX
        public string Action { get; private set; } = null!;     // ✅ FIX
        public string PerformedBy { get; private set; } = null!; // ✅ FIX

        public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
        public string Details { get; private set; } = string.Empty;

        private AuditLog() { } // EF Core

        public AuditLog(string entityName, string action, string performedBy, string details)
        {
            Id = Guid.NewGuid();
            EntityName = entityName;
            Action = action;
            PerformedBy = performedBy;
            Details = details;
            Timestamp = DateTime.UtcNow;
        }
    }
}