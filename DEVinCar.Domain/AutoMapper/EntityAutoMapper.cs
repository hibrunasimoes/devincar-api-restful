using System;
using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.ViewModels;

namespace DEVinCar.Domain.AutoMapper
{
    public class EntityAutoMapper : Profile
    {
        public EntityAutoMapper()
        {
            CreateMap<Address, AddressViewModel>()
                .ForMember(a => a.CityName, o => o.MapFrom(a => a.City.Name))
                .ReverseMap();

            CreateMap<AddressDTO, Address>()
                .ReverseMap();

            CreateMap<CityDTO, City>()
                .ReverseMap();

            CreateMap<GetCityByIdViewModel, City>()
                .ReverseMap();

            CreateMap<GetStateByIdViewModel, State>()
                .ReverseMap();

            CreateMap<CarDTO, Car>()
                .ReverseMap();

            CreateMap<DeliveryDTO, Delivery>()
                .ReverseMap();

            CreateMap<SaleDTO, Sale>()
                .ReverseMap();

            CreateMap<BuyDTO, Sale>()
                .ReverseMap();

            CreateMap<SaleCarDTO, SaleCar>()
                .ReverseMap();

            CreateMap<StateDTO, State>()
                .ReverseMap();

            CreateMap<UserDTO, User>()
                .ReverseMap();
        }
    }
}

