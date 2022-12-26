using System;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Infra.Data.Repositories
{
    public class DeliveryRepository : BaseRepository<Delivery, int>, IDeliveryRepository
    {
        public DeliveryRepository(DevInCarDbContext context) : base(context)
        {
        }

        IQueryable<Delivery> IDeliveryRepository.ListAll()
        {
            return _context.Deliveries
                .Include(d => d.Address)
                .Include(d => d.Sale);
        }
    }
}

