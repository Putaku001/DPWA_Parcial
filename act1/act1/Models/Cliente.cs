using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace act1.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        public int? UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        [Required, StringLength(120)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(30)]
        public string? Telefono { get; set; }

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Direccion { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public ICollection<Destinatario> Destinatarios { get; set; } = new List<Destinatario>();

        public ICollection<Envio> Envios { get; set; } = new List<Envio>();
    }
}
