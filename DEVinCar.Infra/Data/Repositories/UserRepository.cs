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
        public IList<SaleCar> GetBuyerByUserID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<SaleCar> GetSalesByUserID(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertBuy(Sale buy)
        {
            throw new NotImplementedException();
        }

        public void InsertSale(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}

