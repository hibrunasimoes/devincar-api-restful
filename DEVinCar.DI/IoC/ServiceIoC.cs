using System;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Services;
using DEVinCar.Infra.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DEVinCar.DI.IoC
{
    public static class ServiceIoC
    {
        public static IServiceCollection RegisterServices(this IServiceCollection builder)
        {
            return builder
            .AddDbContext<DevInCarDbContext>()
            .AddScoped<IAddressService, AddressService>()
            .AddScoped<ICarService, CarService>()
            .AddScoped<IDeliveryService, DeliveryService>()
            .AddScoped<ISaleService, SaleService>()
            .AddScoped<IStateService, StateService>()
            .AddScoped<IUserService, UserService>();
        }
    }
}

