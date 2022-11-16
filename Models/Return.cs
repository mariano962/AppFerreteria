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
        public int ClienteID { get; set; }

        [Display(Name = "Apellido del cliente")]
        public string? ClienteApellido { get; set; }


        [Display(Name = "Nombre del cliente")]
        public string? ClienteName { get; set; }
        
        
        public virtual Cliente? Cliente { get; set; }

        public  string? CodigoAlfanumericoMotosierra  { get; set; }

        public int MotosierraID { get; set; }

        public virtual Motosierra? Motosierra { get; set; }


        
    }
 }
