using System;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.Data.Repositories
{
    public class StateRepository : BaseRepository<State, int>, IStateRepository
    {
        public StateRepository(DevInCarDbContext context) : base(context)
        {
        }

        public City GetCityById(int cityId)
        {
            throw new NotImplementedException();
        }

        public void InsertAdress(Address adress)
        {
            throw new NotImplementedException();
        }

        public void InsertCity(City city)
        {
            throw new NotImplementedException();
        }
    }
}

