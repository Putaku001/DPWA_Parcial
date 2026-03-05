using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace act1.Models
{
    public class Destinatario
    {
        [Key]
        public int DestinatarioId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; } = null!;

        [Required, StringLength(120)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(30)]
        public string? Telefono { get; set; }

        [StringLength(200)]
        public string? Direccion { get; set; }

        [StringLength(80)]
        public string? Departamento { get; set; }

        [StringLength(80)]
        public string? Municipio { get; set; }

        [StringLength(200)]
        public string? Referencia { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<Envio> Envios { get; set; } = new List<Envio>();
    }
}
