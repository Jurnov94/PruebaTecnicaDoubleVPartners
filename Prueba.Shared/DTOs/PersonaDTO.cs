using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Prueba.Shared.DTOs
{
    public   class PersonaDTO
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
        [EmailAddress(ErrorMessage = "Por favor, ingrese un email válido")]
        public string Email { get; set; } = null!;


        [Display(Name = "IdentificacionConcetenado")]
        public string IdentificacionCompleta => $"{NumeroIdentificacion}{TipoIdentificacion}";


        [Display(Name = "NombreConcetenado")]
        public string NombreCompleto => $"{Nombres} {Apellidos}";

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }

        public IEnumerable<SelectListItem>? TiposdeDocumento { get; set; }



    }
}
