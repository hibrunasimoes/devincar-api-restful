using System;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repository
{
	public interface ICityRepository
	{
        City GetById(int id);
        IList<City> ListAll();
        void Insert(City city);
        void Delete(City city);
        void Update(City city);
    }
}

