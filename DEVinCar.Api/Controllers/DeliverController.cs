using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCar.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Runtime.ConstrainedExecution;
using DEVinCar.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace DEVinCar.Api.Controllers
{
    [ApiController]
    [Route("api/deliver")]
    [Authorize]
    public class DeliverController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        public DeliverController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int? addressId, int? saleId)
        {
            return Ok(_deliveryService.ListAll(addressId, saleId));
        }
    }
}

