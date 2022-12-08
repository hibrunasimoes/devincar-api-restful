using System;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repository
{
    public interface ISaleRepository
    {
        SaleCar GetById(int id);
        void InsertSale(SaleCar saleCar);
        void InsertDelivery(Delivery delivery);
        void UpdateAmount(SaleCar saleCar);
        void UpdatePrice(SaleCar saleCar);
    }
}

