using System.Security.AccessControl;
using System;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Domain.Models;
public class Delivery
{
    public int Id { get; internal set; }
    public DateTime DeliveryForecast { get; set; }
    public int AddressId { get; set; }
    public int SaleId { get; set; }
    public virtual Address Address { get; set; }
    public virtual Sale Sale { get; set; }
    public Delivery()
    {
    }  
}
