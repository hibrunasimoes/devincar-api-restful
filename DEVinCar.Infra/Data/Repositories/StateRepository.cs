using System;
using System.Net;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Infra.Data.Repositories
{
    public class StateRepository : BaseRepository<State, int>, IStateRepository
    {
        public StateRepository(DevInCarDbContext context) : base(context)
        {
        }

        public City GetCityById(int cityId)
        {
            return _context.Cities.Find(cityId);
        }

        public void InsertAdress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void InsertCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }

        IQueryable<State> IStateRepository.ListAll()
        {
            return _context.States
                .Include(s => s.Cities);
        }
    }
}

