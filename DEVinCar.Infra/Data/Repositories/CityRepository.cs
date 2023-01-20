using System;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.Data.Repositories
{
    public class CityRepository : BaseRepository<City, int>, ICityRepository
    {
        public CityRepository(DevInCarDbContext context) : base(context)
        {

        }
    }
}