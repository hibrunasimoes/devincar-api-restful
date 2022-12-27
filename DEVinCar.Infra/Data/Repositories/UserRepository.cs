using System;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(DevInCarDbContext context) : base(context)
        {
        }
        public IList<Sale> GetBuyerByUserID(int id)
        {
            return _context.Sales
                .Where(s => s.BuyerId == id)
                .ToList();
        }
        public IList<Sale> GetSalesByUserID(int id)
        {
            return _context.Sales
                .Where(s => s.SellerId == id)
                .ToList();
        }
        public void InsertBuy(Sale buy)
        {
            _context.Sales.Add(buy);
            _context.SaveChanges();
        }
        public void InsertSale(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }
    }
}

