using System;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address, int>, IAdressRepository
    {
        public AddressRepository(DevInCarDbContext context) : base(context)
        {
        }

    }
}