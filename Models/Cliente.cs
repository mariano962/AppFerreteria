using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppFerreteria.Models
{
 public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }


        [Display(Name = "Nombre del cliente")]
        [Required(ErrorMessage = "Este valor es Obligatorio.")]
        [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? ClienteName { get; set; }

        [Display(Name = "Apellido del cliente")]
        [Required(ErrorMessage = "Este valor es Obligatorio.")]
        [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? ClienteApellido { get; set; }



        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Este valor es Obligatorio.")]
        [MaxLength(100, ErrorMessage = "El largo máximo es de {0} caracteres.")]
        public string? ClientePhone { get; set; }


        [Display(Name = "DNI del Socio")]
        [Required(ErrorMessage = "Este valor es Obligatorio.")]
        [MaxLength(8, ErrorMessage = "El largo máximo es de {0} caracteres.")]
        public string? ClienteDNI { get; set; }

       

        public virtual ICollection<Rental>? Rental { get; set; }

        

    }
}