using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.DTOs
{
    public class SaleDTO
    {
        [Required(ErrorMessage = "The BuyerId is required.")]
        public int BuyerId { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
