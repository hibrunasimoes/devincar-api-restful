using System;
using DEVinCar.Domain.DTOs;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface ICarService
    {
        CarDTO GetById(int id);
        IList<CarDTO> ListAll();
        void Insert(CarDTO DTO);
        void Delete(int id);
        void Update(CarDTO DTO);
    }
}

