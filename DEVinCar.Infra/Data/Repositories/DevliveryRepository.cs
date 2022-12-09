using System;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.Data.Repositories
{
    public class DeliveryRepository : BaseRepository<Delivery, int>, IDeliveryRepository
    {
        public DeliveryRepository(DevInCarDbContext context) : base(context)
        {
        }
    }
}

