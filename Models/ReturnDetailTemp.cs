using System.ComponentModel.DataAnnotations;

namespace AppFerreteria.Models
{
    public class ReturnDetailTemp
    {
          [Key]
    public int ReturnDetailTempID { get; set; }

    
    public int MotosierraID { get; set; }

    [Display(Name = "Nombre de la motosierra")]
    public string? MotosierraName { get; set; }

    }

  
}