using System;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repository
{
    public interface IAdressRepository
    {
        IList<Address> ListAll();
        void Update(Address address);
        void Delete(Address adress);
    }
}
