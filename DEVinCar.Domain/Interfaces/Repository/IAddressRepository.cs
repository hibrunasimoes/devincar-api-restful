using System;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repository
{
    public interface IAddressRepository
    {
        IQueryable<Address> ListAll();
    }
}
