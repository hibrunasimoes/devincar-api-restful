using System;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Infra.Data.Repositories
{
    public class SaleRepository : BaseRepository<Sale, int>, ISaleRepository
    {
        public SaleRepository(DevInCarDbContext context) : base(context)
        {
        }
        public override Sale GetById(int id)
        {
            return _context.Sales.Where(s => s.Id == id)
                .Include(s => s.UserBuyer)
                .Include(s => s.UserSeller)
                .Include(s => s.Cars)
                .FirstOrDefault();
        }
        public void InsertDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
        }

        public void InsertSale(SaleCar saleCar)
        {
            _context.SaleCars.Add(saleCar);
            _context.SaveChanges();
        }

        public void UpdateAmount(SaleCar saleCar)
        {
            _context.SaleCars.Update(saleCar);
            _context.SaveChanges();
        }

        public void UpdatePrice(SaleCar saleCar)
        {
            _context.SaleCars.Update(saleCar);
            _context.SaveChanges();
        }
    }
}


