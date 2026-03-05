using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace act1.Models
{
    public class Paquete
    {
        [Key]
        public int PaqueteId { get; set; }

        [Required]
        public int EnvioId { get; set; }

        [ForeignKey(nameof(EnvioId))]
        public Envio Envio { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Peso { get; set; }
    }
}
