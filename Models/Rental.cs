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
        public int ClienteID { get; set; }

        [Display(Name = "Apellido del cliente")]
        public string? ClienteApellido { get; set; }


        [Display(Name = "Nombre del cliente")]
        public string? ClienteName { get; set; }


        [Display(Name = "Total a pagar")]
        public int MontoTotal { get; set; }




        [Display(Name = "Motosierra ")]
       public  int MotosierraID { get; set; }

        public  string? CodigoAlfanumericoMotosierra  { get; set; }


      [Display(Name = "Cantidad de unidades")]
        public int Stock { get; set; }

        
        public virtual Cliente? Cliente { get; set; }

        public virtual Motosierra? Motosierra { get; set; }



  
    }
 }