using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DEVinCar.Domain.Enums
{
    public enum Roles
    {
        [Display(Name = "Manager")]
        Manager,
        [Display(Name = "Seller")]
        Seller,
        [Display(Name = "Buyer")]
        Buyer
    }
}