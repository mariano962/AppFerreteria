using System.ComponentModel.DataAnnotations;


namespace AppFerreteria.Models
{
    public class RentalDetail
    {
        [Key]
        public int RentalDetailID { get; set; }
        
        
        public int RentalID { get; set; }
        
        public int MotosierrasID { get; set; }
        public virtual Motosierra? Motosierras { get; set; }
        
         [Display(Name = "Nombre de la motosierra")]
        public string? MotosierraName { get; set; }

        [Display(Name = "Codigo Alfanumerico")]
        public string? CodigoAlfanumericoMotosierra { get; set; }


    }
}