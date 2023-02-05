using System;
using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.ViewModels;

namespace DEVinCar.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public StateService(IStateRepository stateRepository, ICityRepository cityRepository, IAddressRepository addressRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public IList<CityDTO> GetCitiesByStateId(int stateId, string name)
        {
            var query = _cityRepository.ListAll().Where(c => c.StateId == stateId).AsQueryable();
            var existsState = _stateRepository.ListAll().Any(s => s.Id == stateId);

            if (!String.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.Contains(name));

            if (!existsState)
                throw new IsExistsException("State not found!");

            if (!query.ToList().Any())
                throw new IsExistsException("Register not found!");

            return _mapper.Map<IList<CityDTO>>(query);
        }

        public GetCityByIdViewModel GetCityById(int stateId, int cityId)
        {
            var city = _cityRepository.GetById(cityId);
            var state = _stateRepository.GetById(stateId);

            if (city == null)
                throw new IsExistsException("City not found!");

            if (city.StateId != stateId)
                throw new NotImplementedException();


            return new GetCityByIdViewModel(state, city);
        }

        public GetStateByIdViewModel GetStateByID(int stateId)
        {
            var stateDb = _stateRepository.GetById(stateId);

            if (stateDb == null)
                throw new IsExistsException("State not found!");

            return _mapper.Map<GetStateByIdViewModel>(stateDb);
        }

        public void InsertAdress(int stateId, int cityId, AddressDTO address)
        {
            var city = _cityRepository.GetById(cityId);

            if (city == null)
                throw new IsExistsException("City not found!");

            if (city.StateId != stateId)
                throw new NotImplementedException();

            _addressRepository.Insert(_mapper.Map<Address>(address));
        }

        public void InsertCity(int stateId, CityDTO city)
        {
            var state = _stateRepository.GetById(stateId);
            var isExistsCity = _cityRepository.ListAll().Any(c => c.Name == city.Name && c.StateId == city.StateId);

            if (state == null)

            if (isExistsCity)

            _cityRepository.Insert(_mapper.Map<City>(city));
        }

        public IList<GetStateViewModel> ListAll(string name)
        {
            var query = _stateRepository.ListAll().AsQueryable();

            if (!String.IsNullOrEmpty(name))
                query = query.Where(s => s.Name.Contains(name));

            if (!query.ToList().Any())
                throw new IsExistsException("Register not found!");

            var states = query.Select(s => new GetStateViewModel(s)).ToList();

            return states;
        }
    }
}

