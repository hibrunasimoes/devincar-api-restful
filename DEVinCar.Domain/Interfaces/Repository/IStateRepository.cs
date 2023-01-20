using System;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repository
{
    public interface IStateRepository
    {
        IQueryable<State> ListAll();
        State GetById(int stateId);
        City GetCityById(int cityId);
        void InsertCity(City city);
        void InsertAdress(Address adress);
    }
}
