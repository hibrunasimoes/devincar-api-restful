using System;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.ViewModels;

namespace DEVinCar.Domain.Services
{
    public class StateService : IStateService
    {
        public GetCityByIdViewModel GetCityById(int cityId)
        {
            throw new NotImplementedException();
        }

        public GetStateByIdViewModel GetStateByID(int stateId)
        {
            throw new NotImplementedException();
        }

        public void InsertAdress(int stateId, int ciryId, AddressDTO adress)
        {
            throw new NotImplementedException();
        }

        public void InsertCity(int stateId, CityDTO city)
        {
            throw new NotImplementedException();
        }

        public IList<GetStateViewModel> ListAll()
        {
            throw new NotImplementedException();
        }
    }
}

