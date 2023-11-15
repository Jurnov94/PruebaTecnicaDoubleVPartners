using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Shared.Entities
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Usuario")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NombreUsuario { get; set; } = null!;

        [Display(Name = "Contraseña")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Password { get; set; } = null!;

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }

    }
}
