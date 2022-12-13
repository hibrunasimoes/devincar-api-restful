using System.ComponentModel.DataAnnotations;
using DEVinCar.Domain.Annotations;
using DEVinCar.Domain.Enums;

namespace DEVinCar.Domain.DTOs{
    public class UserDTO{

        public int Id { get; internal set; }
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The email is required")]
        [MaxLength(150)]
        [EmailAddress(ErrorMessage = "Email must be valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The password is required")]
        [MaxLength(50)]
        [MinLength(4, ErrorMessage = "The password must contain at least 4 digits")]
        [DistinctCharactersAttribute]
        public string Password { get; set; }
        [DataType(DataType.Date, ErrorMessage="Date must be valid")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [CheckAgeAttribute(18)]
        public DateTime BirthDate { get; set; }
        public Roles Role { get; set; }

        public UserDTO()
        {
        }
    }
}