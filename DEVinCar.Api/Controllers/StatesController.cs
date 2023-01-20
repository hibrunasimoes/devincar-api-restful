using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.Interfaces.Services;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/state")]
public class StatesController : ControllerBase
{
    private readonly IStateService _stateService;
    public StatesController(IStateService stateService)
    {
        _stateService = stateService;
    }

    [HttpPost("{stateId}/city")]
    public IActionResult PostCity([FromRoute] int stateId,[FromBody] CityDTO cityDTO)
    {
        _stateService.InsertCity(stateId, cityDTO);
        return Created("api/{stateId}/city", cityDTO);
    }

    [HttpPost("{stateId}/city/{cityId}/address")]
    public IActionResult PostAdress([FromRoute] int stateId, int cityId,[FromBody] AddressDTO body)
    {
        _stateService.InsertAdress(stateId, cityId, body);
        return Created($"api/state/{stateId}/city/{cityId}/", body);
    }

    [HttpGet("{stateId}/city/{cityId}")]
    public IActionResult GetCityById([FromRoute] int stateId, int cityId)
    {
        return Ok(_stateService.GetCityById(stateId, cityId));
    }

    [HttpGet("{stateId}")]
    public IActionResult GetStateById( [FromRoute] int stateId)
    {
        return Ok(_stateService.GetStateByID(stateId));
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string name)
    {
        return Ok(_stateService.ListAll(name));
    }

    [HttpGet("{stateId}/city")]
    public IActionResult GetCityByStateId([FromRoute] int stateId,[FromQuery] string name)
    {
        return Ok(_stateService.GetCitiesByStateId(stateId, name));
    }

}

