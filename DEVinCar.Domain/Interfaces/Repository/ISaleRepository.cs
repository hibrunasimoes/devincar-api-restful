using System;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.ViewModels;

namespace DEVinCar.Domain.Interfaces.Repository
{
    public interface ISaleRepository
    {
        void InsertSale(SaleCar saleCar);
        void InsertDelivery(Delivery delivery);
        void UpdateAmount(SaleCar saleCar);
        void UpdatePrice(SaleCar saleCar);
        Sale GetById(int id);
    }
}

