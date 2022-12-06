using System.ComponentModel.DataAnnotations;

namespace AppFerreteria.Models
{
    public class Motosierra
    {
        [Key]

        public int MotosierraID { get; set; }
        
        [Display(Name = "Codigo Alfanumerico")]
        [Required(ErrorMessage = "Este valor es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? CodigoAlfanumericoMotosierra { get; set; }

        [Display(Name = "Precio de la motosierra")]
        [Required(ErrorMessage = "Este valor es obligatorio.")]
        
        public int PrecioMotosierra { get; set; }


        [Display(Name = "Codigo de Fabrica")]
        [Required(ErrorMessage = "Este valor es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? Codigodefabrica { get; set; }


        [Display(Name = "Stock Inicial")]
        [Required(ErrorMessage = "Este valor es obligatorio.")]
        public int StockStart { get; set; }

        [Display(Name = "Stock Actual")]
       
        public int Stock { get; set; }


      
        [Display(Name = "Imagen")]
        public byte[]? MotosierraImg { get; set; }
        

        

        [Display(Name = "Libre")]
        public bool isDeleted { get; set; }
        

        
    }
        

    }
