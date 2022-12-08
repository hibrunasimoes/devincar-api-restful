using System;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.ViewModels;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IStateService
    {
        IList<GetStateViewModel> ListAll();
        GetStateByIdViewModel GetStateByID(int stateId);
        GetCityByIdViewModel GetCityById(int cityId);
        void InsertCity(int stateId, CityDTO city);
        void InsertAdress(int stateId, int ciryId, AddressDTO adress);
    }
}

