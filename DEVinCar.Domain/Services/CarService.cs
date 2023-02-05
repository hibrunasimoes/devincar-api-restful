using System;
using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Domain.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly ISaleCarRepository _saleCarRepository;

        public CarService(ICarRepository carRepository, IMapper mapper, ISaleCarRepository saleCarRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _saleCarRepository = saleCarRepository;
        }

        public void Delete(int id)
        {
           var carDb = _carRepository.GetById(id);
           var soldCar = _saleCarRepository.ListAll().Any(s => s.CarId == id);
            if (carDb == null)
            {
                throw new IsExistsException("car not found!");
            }

            if (soldCar)
            {
                throw new Exception("!");
            }

            _carRepository.Delete(carDb);
        }

        public CarDTO GetById(int id)
        {
            var carDb = _carRepository.GetById(id);
            if (carDb == null)
            {
                throw new IsExistsException("car not found!");
            }
            return _mapper.Map<CarDTO>(carDb);
        }

        public void Insert(CarDTO DTO)
        {
            _carRepository.Insert(_mapper.Map<Car>(DTO));
        }

        public IList<CarDTO> ListAll(string name, decimal? priceMin, decimal? priceMax)
        {
            var query = _carRepository.ListAll().AsQueryable();

            if (!String.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.Contains(name));

            if (priceMin > priceMax)
            {
                throw new Exception("!");
            }
            if (priceMin.HasValue)
                query = query.Where(c => c.SuggestedPrice >= priceMin);

            if (priceMax.HasValue)
                query = query.Where(c => c.SuggestedPrice <= priceMax);

            if (!query.ToList().Any())
            {
                throw new IsExistsException("car register not found!");
            }

            return _mapper.Map<IList<CarDTO>>(query).ToList();
        }

        public void Update(CarDTO DTO)
        {
            var carDb = _carRepository.GetById(DTO.Id);
            var name = _carRepository.ListAll()
                  .Any(c => c.Name == DTO.Name && c.Id != DTO.Id);
            if (carDb == null)
            {
                throw new IsExistsException("car not found!");
            }

            if (carDb.Name.Equals(null) || DTO.SuggestedPrice.Equals(null))
            {
                throw new Exception("!");
            }

            if (DTO.SuggestedPrice <= 0)
            {
                throw new Exception("!");
            }

            if (name)
            {
                throw new Exception("!");
            }
            carDb.Update(DTO);
            _carRepository.Update(carDb);
        }
    }
}

