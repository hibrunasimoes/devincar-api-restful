using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCar.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.Interfaces.Services;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/user")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string Name, DateTime? birthDateMax, DateTime? birthDateMin)
    {
        return Ok(_userService.ListAll(Name, birthDateMax, birthDateMin));
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        return Ok(_userService.GetById(id));
    }

    [HttpGet("{userId}/buy")]
    public IActionResult GetByIdbuy([FromRoute] int userId)
    {
        return Ok(_userService.GetBuyerByUserID(userId));
    }

    [HttpGet("{userId}/sales")]
    public IActionResult GetSalesBySellerId([FromRoute] int userId)
    {
        return Ok(_userService.GetSalesByUserID(userId));
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserDTO userDto)
    {
        _userService.Insert(userDto);
        return Created("api/users", userDto);
    }

    [HttpPost("{userId}/sales")]
    public IActionResult PostSaleUserId([FromRoute] int userId,[FromBody] SaleDTO body)
    {
        _userService.InsertSale(userId, body);
        return Created("api/sale", body);
    }

    [HttpPost("{userId}/buy")]
    public IActionResult PostBuyUserId([FromRoute] int userId,[FromBody] BuyDTO body)
    {
        _userService.InsertBuy(userId, body);
        return Created("api/user/{userId}/buy", body);
    }
     
    [HttpDelete("{userId}")]
    public IActionResult Delete([FromRoute] int userId)
    {
        _userService.DeleteUser(userId);
        return NoContent();
    }
}





