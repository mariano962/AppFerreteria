using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppFerreteria.Models
{
 public class Partner
    {
        [Key]
        public int PartnerID { get; set; }


        [Display(Name = "Nombre del cliente")]
        [Required(ErrorMessage = "Este valor es Obligatorio.")]
        [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? PartnerName { get; set; }

        [Display(Name = "Apellido del cleinte")]
        [Required(ErrorMessage = "Este valor es Obligatorio.")]
        [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? PartnerApellido { get; set; }



        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Este valor es Obligatorio.")]
        [MaxLength(100, ErrorMessage = "El largo máximo es de {0} caracteres.")]
        public string? PartnerPhone { get; set; }


        [Display(Name = "DNI del Socío")]
        [Required(ErrorMessage = "Este valor es Obligatorio.")]
        [MaxLength(8, ErrorMessage = "El largo máximo es de {0} caracteres.")]
        public string? PartnerDNI { get; set; }

       

        public virtual ICollection<Rental>? Rental { get; set; }

        

    }
}