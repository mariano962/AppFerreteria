using System.ComponentModel.DataAnnotations;

namespace AppFerreteria.Models
{
    public class Return
    {
        [Key]
        public int ReturnID {get; set;}
        
        
        [Display(Name = "Fecha de Devolución")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        
        [Display(Name = "Cliente")]
        public int PartnerID { get; set; }
        
        [Display(Name = "Cliente")]
        public virtual Partner? Partner { get; set; }

        public  string? CodigoAlfanumericoMotosierra  { get; set; }

        public int MotosierraID { get; set; }

        public virtual Motosierra? Motosierra { get; set; }


        
    }
 }
