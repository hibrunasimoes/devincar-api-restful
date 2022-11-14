using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCar.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace DEVinCar.Api.Controllers
{
    [ApiController]
    [Route("api/deliver")]
    public class DeliverController : ControllerBase
    {
        private readonly DevInCarDbContext _context;
        public DeliverController(DevInCarDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<Delivery> Get(
        [FromQuery] int? addressId,
        [FromQuery] int? saleId)
        {
            var query = _context.Deliveries.AsQueryable();

            if (addressId.HasValue)
            {
                query = query.Where(a => a.AddressId == addressId);
            }

            if (saleId.HasValue)
            {
                query = query.Where(s => s.SaleId == saleId);
            }
                      
            if (!query.ToList().Any())
            {
                return NoContent();
            }

            return Ok(query.ToList());
       
        }
    }
}

