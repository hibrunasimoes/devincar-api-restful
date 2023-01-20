using System;
using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Domain.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        private readonly IDeliveryRepository _deliveryRepository;

        public AddressService(IAddressRepository addressRepository, IMapper mapper, IDeliveryRepository deliveryRepository)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _deliveryRepository = deliveryRepository;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<AddressViewModel> ListAll(int? cityId, int? stateId, string street, string cep)
        {
            var query = _addressRepository.ListAll().AsQueryable();

            if (cityId.HasValue)
            {
                query = query.Where(a => a.CityId == cityId);
            }
            if (stateId.HasValue)
            {
                query = query.Where(a => a.City.StateId == stateId);
            }

            if (!string.IsNullOrEmpty(street))
            {
                street = street.ToUpper();
                query = query.Where(a => a.Street.Contains(street));
            }

            if (!string.IsNullOrEmpty(cep))
            {
                query = query.Where(a => a.Cep == cep);
            }

            if (!query.ToList().Any())
            {
                throw new NotImplementedException();
            }

            return _mapper.Map<IList<AddressViewModel>>(query).ToList();
        }

        public void Update(AddressPatchDTO addressPatchDTO, int id)
        {
            throw new NotImplementedException();
        }
    }
}

