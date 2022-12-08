using System;
using DEVinCar.Domain.DTOs;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IAddressService
    {
        IList<AddressDTO> ListAll();
        void Update(AddressPatchDTO addressPatchDTO);
        void Delete(int id);
    }
}

