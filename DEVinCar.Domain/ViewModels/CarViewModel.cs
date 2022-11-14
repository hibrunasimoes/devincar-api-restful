using DEVinCar.Domain.Models;
namespace DEVinCar.Domain.ViewModels;
public class CarViewModel
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int? Amount { get; set; }
    public decimal Total { get; set; }
    public CarViewModel()
    {
    }
}