using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace act1.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [Required, StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
