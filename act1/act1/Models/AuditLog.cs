using System;
using System.ComponentModel.DataAnnotations;

namespace act1.Models
{
    public class AuditLog
    {
        [Key]
        public long AuditLogId { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public int? UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        [Required, StringLength(20)]
        public string Action { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string EntityName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string EntityId { get; set; } = string.Empty;

        public string? ChangedColumns { get; set; }

        public string? OldValuesJson { get; set; }

        public string? NewValuesJson { get; set; }

        [StringLength(100)]
        public string? CorrelationId { get; set; }
    }
}
