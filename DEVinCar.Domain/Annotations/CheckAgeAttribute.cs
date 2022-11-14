using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.Annotations;

public class CheckAgeAttribute : ValidationAttribute
{
    private readonly int _age;

    public CheckAgeAttribute(int age)
    {
        _age = age;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        
        if(Convert.ToDateTime(value).AddYears(_age) <= DateTime.Now)
        {
            return ValidationResult.Success;
        }
        return new ValidationResult($"User must be older than {_age} years");
    }

}
