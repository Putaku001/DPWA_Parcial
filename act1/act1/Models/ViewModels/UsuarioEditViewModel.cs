using System.ComponentModel.DataAnnotations;

namespace act1.Models.ViewModels
{
    public class UsuarioEditViewModel
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required, StringLength(80)]
        public string Username { get; set; } = string.Empty;

        [StringLength(150)]
        public string? Email { get; set; }

        [Required]
        public int RolId { get; set; }

        public bool Activo { get; set; }

        [DataType(DataType.Password), MinLength(6)]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password), Compare(nameof(NewPassword))]
        public string? ConfirmNewPassword { get; set; }
    }
}
