namespace DEVinCar.Domain.Models
{
    public class SaleCar
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int? Amount { get; set; }
        public int CarId { get; set; }
        public int SaleId { get; set; }
        public virtual Car Car { get; set; }
        public virtual Sale Sale { get; set; }
        public SaleCar()
        {
        }
        public decimal Sum(decimal UnitPrice, int? Amount)
        {
            return UnitPrice * (int)Amount;
        }
    }
}
