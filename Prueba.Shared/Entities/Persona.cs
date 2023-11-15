using System.ComponentModel.DataAnnotations;

namespace Prueba.Shared.Entities
{
    public class Persona
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombres { get; set; } = null!;

        [Display(Name = "Apellidos")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Apellidos { get; set; } = null!;

        [Display(Name = "Tipo de Identificacón")]
        public string TipoIdentificacion { get; set; } = null!;

        [Display(Name = "Número Identificación")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int NumeroIdentificacion { get; set; }

        [Display(Name = "Email")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; } = null!;

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }







    }
}
