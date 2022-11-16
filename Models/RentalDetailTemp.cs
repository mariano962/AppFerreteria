using System.ComponentModel.DataAnnotations;

namespace AppFerreteria.Models
{
    public class RentalDetailTemp
    {
          [Key]
    public int RentalDetailTempID { get; set; }

    
    public int MotosierraID { get; set; }

    [Display(Name = "Nombre de la motosierra")]
    public string? MotosierraName { get; set; }

    [Display(Name = "Codigo Alfanumerico")]
     public string? CodigoAlfanumericoMotosierra { get; set; }


    

    }

  
}