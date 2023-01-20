using System;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Infra.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address, int>, IAddressRepository
    {
        public AddressRepository(DevInCarDbContext context) : base(context)
        {
        }

        IQueryable<Address> IAddressRepository.ListAll()
        {
            return _context.Addresses.Include(a => a.City);
        }
    }
}