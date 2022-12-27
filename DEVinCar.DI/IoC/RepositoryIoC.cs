using System;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Infra.Data;
using DEVinCar.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DEVinCar.DI.IoC
{
    public static class RepositoryIoC
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection builder)
        {
            return builder
                .AddScoped<IAdressRepository, AddressRepository>()
                .AddScoped<ICarRepository, CarRepository>()
                .AddScoped<IDeliveryRepository, DeliveryRepository>()
                .AddScoped<ISaleRepository, SaleRepository>()
                .AddScoped<IStateRepository, StateRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ISaleCarRepository, SaleCarRepository>();
        }
    }
}