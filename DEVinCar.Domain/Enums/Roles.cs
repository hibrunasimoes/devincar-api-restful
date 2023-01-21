using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
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

    public static class EnumExtensions
    {
        public static string GetName(this Enum enumValue)
        {
            string? displayName;
            displayName = enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()
              ?.GetCustomAttribute<DisplayAttribute>()
              ?.GetName();

            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
}