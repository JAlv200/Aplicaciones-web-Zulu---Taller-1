using System.ComponentModel.DataAnnotations;

namespace Taller.Shared.Entities;

public class Employee
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Apellido")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Activo")]
    public bool? IsActive { get; set; }

    [Display(Name = "FechaContratación")]
    public DateTime? HireDate { get; set; }

    [Display(Name = "Salario")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Range(1000000, double.MaxValue, ErrorMessage = "El salario minimo debe de ser de ${1:N2}")]
    public decimal Salary { get; set; }
}