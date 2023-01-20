using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCar.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.ViewModels;
using DEVinCar.Domain.Interfaces.Services;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/address")]

public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressesController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int? cityId, int? stateId, string street,string cep)
    {
        var result = _addressService
       .ListAll(cityId, stateId, street, cep);

        return Ok(result);
    }

    [HttpPatch("{addressId}")]
    public IActionResult Patch([FromRoute] int addressId,[FromBody] AddressPatchDTO addressPatchDTO)
    {
        _addressService.Update(addressPatchDTO, addressId);
        return NoContent();
    }

    [HttpDelete("{addressId}")]
    public IActionResult Delete([FromRoute] int addressId)
    {
        _addressService.Delete(addressId);
        return NoContent();
    }
}
