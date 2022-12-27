using DEVinCar.Infra.Data;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.Services;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/car")]
public class CarController : ControllerBase
{
    private readonly CarService _carService;

    public CarController(CarService carService)
    {
        _carService = carService;
    }

    [HttpGet("{carId}")]
    public IActionResult GetById([FromRoute] int carId)
    {
        return Ok(_carService.GetById(carId));
    }

    [HttpGet]
    public IActionResult Get(
        [FromQuery] string name, decimal? priceMin, decimal? priceMax)
    {
        return Ok(_carService.ListAll(name, priceMin, priceMax));
    }

    [HttpPost]
    public IActionResult Post([FromBody] CarDTO body)
    {
        _carService.Insert(body);
        return Created("api/car", body);
    }

    [HttpDelete("{carId}")]
    public IActionResult Delete([FromRoute] int carId)
    {
        _carService.Delete(carId);
        return NoContent();
    }

    [HttpPut("{carId}")]
    public IActionResult Put([FromBody] CarDTO carDto,[FromRoute] int carId)
    {
        carDto.Id = carId;
        _carService.Update(carDto);
        return NoContent();
    }
}
