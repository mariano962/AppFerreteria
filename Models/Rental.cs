using System.ComponentModel.DataAnnotations;

namespace AppFerreteria.Models
{
    public class Rental
    {
        [Key]
        public int RentalID {get; set;}
        
        
        [Display(Name = "Fecha de alquiler")]
        [DataType(DataType.Date)]
        public DateTime RentalDate { get; set; }

        
        [Display(Name = "Cliente")]
        public int PartnerID { get; set; }


        [Display(Name = "Motosierra ")]
       public  int? MotosierraID { get; set; }

        public  string? CodigoAlfanumericoMotosierra  { get; set; }

        public string? MotosierraName { get; set; }


        
        public virtual Partner? Partner { get; set; }

        public virtual Motosierra? Motosierra { get; set; }

  
    }
 }