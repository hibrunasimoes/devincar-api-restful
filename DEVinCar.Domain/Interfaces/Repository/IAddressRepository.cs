using System;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repository
{
    public interface IAddressRepository
    {
        void Delete(Address addressDb);
        Address GetById(int id);
        void Insert(Address address);
        IQueryable<Address> ListAll();
        void Update(Address addressDb);
    }
}
