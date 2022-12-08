using System;
using DEVinCar.Domain.DTOs;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface ISaleService
    {
        SaleCarDTO GetById(int id);
        void InsertSale(SaleCarDTO dto);
        void InsertDelivery(DeliveryDTO dto);
        void UpdateAmount(int amount);
        void UpdatePrice(decimal price);
    }
}

