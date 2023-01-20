using System;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repository
{
	public interface ISaleCarRepository
	{
        SaleCar GetById(int id);
        IQueryable<SaleCar> ListAll();
    }
}

