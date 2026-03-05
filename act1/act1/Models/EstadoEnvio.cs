using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace act1.Models
{
    public class EstadoEnvio
    {
        [Key]
        public int EstadoId { get; set; }

        [Required, StringLength(60)]
        public string NombreEstado { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Descripcion { get; set; }

        public int Orden { get; set; }

        public bool BloqueaEdicionCliente { get; set; }

        public ICollection<Envio> Envios { get; set; } = new List<Envio>();
    }
}
