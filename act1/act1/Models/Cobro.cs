using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace act1.Models
{
    public class Cobro
    {
        [Key]
        public long CobroId { get; set; }

        [Required]
        public int EnvioId { get; set; }

        [ForeignKey(nameof(EnvioId))]
        public Envio Envio { get; set; } = null!;

        [Required]
        public DateTime FechaCobro { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        public int? UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public Usuario? Usuario { get; set; }

        [StringLength(200)]
        public string? Observacion { get; set; }
    }
}
