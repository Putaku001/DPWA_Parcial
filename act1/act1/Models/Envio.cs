using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace act1.Models
{
    public class Envio
    {
        [Key]
        public int EnvioId { get; set; }

        [Required, StringLength(50)]
        public string NumeroGuia { get; set; } = string.Empty;

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaEtiquetaGenerada { get; set; }

        public DateTime? FechaRecoleccion { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; } = null!;

        [Required]
        public int SucursalId { get; set; }

        [ForeignKey(nameof(SucursalId))]
        public Sucursal Sucursal { get; set; } = null!;

        [Required]
        public int DestinatarioId { get; set; }

        [ForeignKey(nameof(DestinatarioId))]
        public Destinatario Destinatario { get; set; } = null!;

        [Required, StringLength(120)]
        public string DestinatarioNombre { get; set; } = string.Empty;

        [StringLength(30)]
        public string? DestinatarioTelefono { get; set; }

        [Required, StringLength(200)]
        public string EntregaDireccion { get; set; } = string.Empty;

        [Required, StringLength(80)]
        public string EntregaDepartamento { get; set; } = string.Empty;

        [Required, StringLength(80)]
        public string EntregaMunicipio { get; set; } = string.Empty;

        [StringLength(200)]
        public string? EntregaReferencia { get; set; }

        [Required]
        public int EstadoId { get; set; }

        [ForeignKey(nameof(EstadoId))]
        public EstadoEnvio EstadoEnvio { get; set; } = null!;

        [Required]
        public DateTime FechaEnvio { get; set; } = DateTime.Now;

        public DateTime? FechaEntrega { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Costo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioBase { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Recargo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Descuento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Comision { get; set; }

        public ICollection<Paquete> Paquetes { get; set; } = new List<Paquete>();

        public ICollection<Cobro> Cobros { get; set; } = new List<Cobro>();
    }
}
