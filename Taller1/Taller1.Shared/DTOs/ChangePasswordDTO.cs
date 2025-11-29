using System.ComponentModel.DataAnnotations;

namespace Taller.Shared.DTOs;

public class ChangePasswordDTO
{
    [DataType(DataType.Password)]
    [Display(Name = "Contraseña Actual")]
    [StringLength(20, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} carácteres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string CurrentPassword { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Nueva Contraseña")]
    [StringLength(20, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} carácteres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string NewPassword { get; set; } = null!;

    [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la confirmación no coinciden.")]
    [DataType(DataType.Password)]
    [Display(Name = "Contraseña Actual")]
    [StringLength(20, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} carácteres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Confirm { get; set; } = null!;
}