using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCar.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.ViewModels;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/address")]

public class AddressesController : ControllerBase
{
    private readonly DevInCarDbContext _context;

    public AddressesController(DevInCarDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<AddressViewModel>> Get([FromQuery] int? cityId,
                                                    [FromQuery] int? stateId,
                                                    [FromQuery] string street,
                                                    [FromQuery] string cep)
    {
        var query = _context.Addresses.AsQueryable();

        if (cityId.HasValue)
        {
            query = query.Where(a => a.CityId == cityId);
        }
        if (stateId.HasValue)
        {
            query = query.Where(a => a.City.StateId == stateId);
        }

        if (!string.IsNullOrEmpty(street))
        {
            street = street.ToUpper();
            query = query.Where(a => a.Street.Contains(street));
        }

        if (!string.IsNullOrEmpty(cep))
        {
            query = query.Where(a => a.Cep == cep);
        }

        if (!query.ToList().Any())
        {
            return NoContent();
        }

        List<AddressViewModel> addressesViewModel = new List<AddressViewModel>();
        query
            .Include(a => a.City)
            .ToList().ForEach(address => {
            addressesViewModel.Add(new AddressViewModel(address.Id,
                                                        address.Street,
                                                        address.CityId,
                                                        address.City.Name,
                                                        address.Number,
                                                        address.Complement,
                                                        address.Cep));
        });
        return Ok(addressesViewModel);

    }

    [HttpPatch("{addressId}")]
    public ActionResult<AddressViewModel> Patch([FromRoute] int addressId,
                                       [FromBody] AddressPatchDTO addressPatchDTO)
    {

        Address address = _context.Addresses
                                  .Include(a => a.City)
                                  .FirstOrDefault(a => a.Id == addressId);

        if (address == null)
            return NotFound($"The address with ID: {addressId} not found.");

        string street = addressPatchDTO.Street ?? null;
        string cep = addressPatchDTO.Cep ?? null;
        string complement = addressPatchDTO.Complement ?? null;

        if (street != null)
        {
            if (addressPatchDTO.Street == "")
                return BadRequest("The street name cannot be empty.");
            address.Street = street;
        }

        if (addressPatchDTO.Cep != null)
        {
            if (addressPatchDTO.Cep == "")
                return BadRequest("The cep cannot be empty.");
            if (!addressPatchDTO.Cep.All(char.IsDigit))
                return BadRequest("Every characters in cep must be numeric.");
            address.Cep = cep;
        }

        if (addressPatchDTO.Complement != null)
        {
            if (addressPatchDTO.Complement == "")
                return BadRequest("The complement cannot be empty.");
            address.Complement = complement;
        }

        if (addressPatchDTO.Number != 0)
            address.Number = addressPatchDTO.Number;

        _context.SaveChanges();

        AddressViewModel addressViewModel = new AddressViewModel(
            address.Id,
            address.Street,
            address.CityId,
            address.City.Name,
            address.Number,
            address.Complement,
            address.Cep
        );
        return Ok(addressViewModel);
    }

    [HttpDelete("{addressId}")]

    public ActionResult DeleteById([FromRoute] int addressId)
    {
        Address address = _context.Addresses.Find(addressId);

        if (address == null)
        {
            return NotFound($"The address with ID: {addressId} not found.");
        }

        Delivery relation = _context.Deliveries.FirstOrDefault(d => d.AddressId == addressId);

        if (relation != null)
        {
            return BadRequest($"The address with ID: {addressId} is related to a delivery.");
        }

        _context.Addresses.Remove(address);
        _context.SaveChanges();

        return NoContent();
    }
}
