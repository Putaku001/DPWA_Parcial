using System.ComponentModel.DataAnnotations;

namespace act1.Models.ViewModels
{
    public class UsuarioCreateViewModel
    {
        [Required, StringLength(80)]
        public string Username { get; set; } = string.Empty;

        [StringLength(150)]
        public string? Email { get; set; }

        [Required]
        public int RolId { get; set; }

        public bool Activo { get; set; } = true;

        [Required, DataType(DataType.Password), MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
