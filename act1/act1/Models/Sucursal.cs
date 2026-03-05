using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace act1.Models
{
    public class Sucursal
    {
        [Key]
        public int SucursalId { get; set; }

        [Required, StringLength(120)]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string Direccion { get; set; } = string.Empty;

        [Required, StringLength(80)]
        public string Departamento { get; set; } = string.Empty;

        [Required, StringLength(80)]
        public string Municipio { get; set; } = string.Empty;

        [StringLength(30)]
        public string? Telefono { get; set; }

        public bool Activa { get; set; } = true;

        public ICollection<Envio> Envios { get; set; } = new List<Envio>();
    }
}
