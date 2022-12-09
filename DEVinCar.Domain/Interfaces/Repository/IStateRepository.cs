using System;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repository
{
    public interface IStateRepository
    {
        IList<State> ListAll();
        State GetById(int stateId);
        City GetCityById(int cityId);
        void InsertCity(City city);
        void InsertAdress(Address adress);
    }
}
