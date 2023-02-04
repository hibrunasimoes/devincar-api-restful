using System.Linq;
using DEVinCar.Infra.Data;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DEVinCar.Domain.ViewModels;
using DEVinCar.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/sales")]
[Authorize]
public class SalesController : ControllerBase
{
    private readonly ISaleService _saleService;
    public SalesController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpGet("{saleId}")]
    public IActionResult Get([FromRoute] int saleId)
    {
        var sale = _saleService.GetById(saleId);
        return Ok(sale);
    }

    [HttpPost("{saleId}/item")]
    [Authorize(Roles = "Manager, Seller")]
    public IActionResult Post([FromBody] SaleCarDTO body,[FromRoute] int saleId)
    {
        _saleService.InsertSale(body, saleId);
        return Created("api/sales/{saleId}/item", body);
    }

    [HttpPost("{saleId}/deliver")]
    public IActionResult Post([FromRoute] int saleId,[FromBody] DeliveryDTO body)
    {
        _saleService.InsertDelivery(body, saleId);
        return Created("api/sales/{saleId}/deliver", body);
    }

    [HttpPatch("{saleId}/car/{carId}/amount/{amount}")]
    public IActionResult Patch([FromRoute] int saleId, int carId, int amount)
    {
        _saleService.UpdateAmount(saleId, carId, amount);
        return NoContent();
    }

    [HttpPatch("{saleId}/car/{carId}/price/{unitPrice}")]
    public IActionResult Patch([FromRoute] int saleId,int carId, decimal unitPrice)
    {
        _saleService.UpdatePrice(saleId, carId, unitPrice);
        return NoContent();
    }
}
