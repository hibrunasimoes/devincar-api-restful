using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.DTOs
{
    public class CarDTO
    {
        public int Id { get; internal set; }
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        public decimal SuggestedPrice { get; set; }

    }
}
