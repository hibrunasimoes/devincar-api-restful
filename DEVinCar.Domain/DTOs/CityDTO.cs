using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.DTOs
{
     public class CityDTO
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(255)]  
        public string Name { get; set; }

       
       
    }
}