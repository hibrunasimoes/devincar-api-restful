using System;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.Data.Repositories
{
    public class SaleCarRepository : BaseRepository<SaleCar, int>, ISaleCarRepository
    {
        public SaleCarRepository(DevInCarDbContext context) : base(context)
        {

        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public void Insert(Car car)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }

        IQueryable<SaleCar> ISaleCarRepository.ListAll()
        {
            throw new NotImplementedException();
        }
    }
}