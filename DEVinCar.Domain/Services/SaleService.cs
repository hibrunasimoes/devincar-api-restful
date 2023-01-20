using System;
using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.ViewModels;

namespace DEVinCar.Domain.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ICarRepository _carRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ISaleCarRepository _saleCarRepository;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository saleRepository, IMapper mapper,
            ICarRepository carRepository, IAddressRepository addressRepository,
            ISaleCarRepository saleCarRepository)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _carRepository = carRepository;
            _addressRepository = addressRepository;
            _saleCarRepository = saleCarRepository;
        }
        public SaleViewModel GetById(int id)
        {
            var saleDb = _saleRepository.GetById(id);
            var salecarDb = _saleCarRepository.ListAll().Where(sc => sc.SaleId == id);

            if (saleDb == null)
                throw new NotImplementedException();

            var saleViewModel = new SaleViewModel(saleDb);
            saleViewModel.Itens = salecarDb.Select(sc => new CarViewModel(sc)).ToList();

            return saleViewModel;
        }

        public void InsertDelivery(DeliveryDTO dto, int id)
        {

            var sale = _saleRepository.GetById(id);
            var address = _addressRepository.GetById(dto.AddressId);

            if (sale == null || address == null)
                throw new NotImplementedException();

            if (dto.DeliveryForecast < DateTime.Now.Date)
                throw new NotImplementedException();

            var delivery = _mapper.Map<Delivery>(dto);
            delivery.Address = address;
            delivery.Sale = sale;

            _saleRepository.InsertDelivery(delivery);
        }

        public void InsertSale(SaleCarDTO dto, int id)
        {
            var carDb = _carRepository.GetById(dto.CarId);
            var saleDb = _saleRepository.GetById(dto.SaleId);

            if (carDb == null && saleDb == null)
                throw new NotImplementedException();

            if (dto.UnitPrice <= 0 || dto.Amount <= 0)
                throw new NotImplementedException();

            if (dto.UnitPrice == null)
                dto.UnitPrice = carDb.SuggestedPrice;

            if (dto.Amount == null)
                dto.Amount = 1;

            var saleCar = _mapper.Map<SaleCar>(dto);
            saleCar.Car = carDb;
            saleCar.Sale = saleDb;

            _saleRepository.InsertSale(saleCar);
        }

        public void UpdateAmount(int saleId, int carId, int amount)
        {
            var sale = _saleRepository.GetById(saleId);
            var saleCar = _saleCarRepository.GetById(carId);

            if (sale == null || saleCar == null)
                throw new NotImplementedException();

            if (amount <= 0)
                throw new NotImplementedException();

            saleCar.Amount = amount;
            _saleRepository.UpdateAmount(saleCar);
        }

        public void UpdatePrice(int saleId, int carId, decimal unitPrice)
        {
            var sale = _saleRepository.GetById(saleId);
            var saleCar = _saleCarRepository.GetById(carId);

            if (sale == null || saleCar == null)
                throw new NotImplementedException();

            if (unitPrice <= 0)
                throw new NotImplementedException();

            saleCar.UnitPrice = unitPrice;
            _saleRepository.UpdateAmount(saleCar);
        }
    }
}

