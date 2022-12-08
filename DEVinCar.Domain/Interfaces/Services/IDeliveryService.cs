using System;
using DEVinCar.Domain.DTOs;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IDeliveryService
    {
        IList<DeliveryDTO> ListAll();
    }
}

