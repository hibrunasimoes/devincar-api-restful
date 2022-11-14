using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.Annotations;

public class DistinctCharactersAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   
        string password = value.ToString();
        var arrPassword = password.ToCharArray().ToList();

        foreach (char letter in arrPassword){
            if(letter != arrPassword[0])
                return ValidationResult.Success;
        } 
        return new ValidationResult("Invalid Password.");    
    }
}