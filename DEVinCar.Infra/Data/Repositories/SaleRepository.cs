using System;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.Data.Repositories
{
    public class SaleRepository : BaseRepository<Sale, int>, ISaleRepository
    {
        public SaleRepository(DevInCarDbContext context) : base(context)
        {
        }

        public void InsertDelivery(Delivery delivery)
        {
            throw new NotImplementedException();
        }

        public void InsertSale(SaleCar saleCar)
        {
            throw new NotImplementedException();
        }

        public void UpdateAmount(SaleCar saleCar)
        {
            throw new NotImplementedException();
        }

        public void UpdatePrice(SaleCar saleCar)
        {
            throw new NotImplementedException();
        }

        SaleCar ISaleRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}


