using System.ComponentModel.DataAnnotations;


namespace AppFerreteria.Models
{
    public class ReturnDetail
    {
        [Key]
        public int ReturnDetailID { get; set; }
        
        
        public int ReturnID { get; set; }
        
        public int MotosierraID { get; set; }
        public virtual Motosierra? Motosierra { get; set; }
        
         [Display(Name = "Nombre de la motosierra")]
        public string? MotosierraName { get; set; }

    }
}