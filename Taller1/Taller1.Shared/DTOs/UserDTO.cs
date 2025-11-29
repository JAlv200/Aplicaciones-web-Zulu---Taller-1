using System.ComponentModel.DataAnnotations;
using Taller.Shared.Entities;

namespace Taller.Shared.DTOs;

public class UserDTO : User
{
    [DataType(DataType.Password)]
    [Display(Name = "Contraseña")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(20, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} carácteres.")]
    public string password { get; set; } = null!;

    [Compare("password", ErrorMessage = "La contraseña y la confirmación no coinciden.")]
    [Display(Name = "Confirmación de contraseña")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(20, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} carácteres.")]
    public string passwordConfirm { get; set; } = null!;
}