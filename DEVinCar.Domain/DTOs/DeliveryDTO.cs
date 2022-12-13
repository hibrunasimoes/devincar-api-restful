namespace DEVinCar.Domain.DTOs;

public class DeliveryDTO
{
    public int Id { get; internal set; }
    public int AddressId { get; set; }
    public DateTime DeliveryForecast { get; set; }
    public int SaleId { get; set; }
}