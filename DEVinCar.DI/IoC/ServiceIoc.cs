using System;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Services;
using DEVinCar.Infra.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DEVinCar.DI.IoC
{
    public static class ServiceIoC
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services;

        }
    }
}