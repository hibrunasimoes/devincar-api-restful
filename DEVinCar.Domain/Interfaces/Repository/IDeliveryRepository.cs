using System;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repository
{
    public interface IDeliveryRepository
    {
        IQueryable<Delivery> ListAll();
    }
}

