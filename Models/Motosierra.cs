using System.ComponentModel.DataAnnotations;

namespace AppFerreteria.Models
{
    public class Motosierra
    {
        [Key]

        public int MotosierraID { get; set; }


        [Display(Name = "Nombre de la motosierra")]
        [Required(ErrorMessage = "Este valor es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? MotosierraName { get; set; }

        
        [Display(Name = "Codigo Alfanumerico")]
        [Required(ErrorMessage = "Este valor es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? CodigoAlfanumericoMotosierra { get; set; }

        [Display(Name = "Precio de la motosierra")]
        [Required(ErrorMessage = "Este valor es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? PrecioMotosierra { get; set; }


        [Display(Name = "Codigo de Fabrica")]
        [Required(ErrorMessage = "Este valor es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? Codigodefabrica { get; set; }


      
        [Display(Name = "Imagen")]
        public byte[]? MotosierraImg { get; set; }
        

        [Display(Name = "Alquilada")]
        public bool EstaAlquilada { get; set; }

        [Display(Name = "Libre")]
        public bool isDeleted { get; set; }
        

        
    }
        

    }
