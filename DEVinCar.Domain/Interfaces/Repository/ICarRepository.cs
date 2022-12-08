using System;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repository
{
    public interface ICarRepository
    {
        Car GetById(int id);
        IList<Car> ListAll();
        void Insert(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}

