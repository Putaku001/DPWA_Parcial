using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace act1.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required, StringLength(80)]
        public string Username { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public int RolId { get; set; }

        public Rol Rol { get; set; } = null!;

        [StringLength(150)]
        public string? Email { get; set; }

        public bool Activo { get; set; } = true;

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public Cliente? Cliente { get; set; }

        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    }
}
