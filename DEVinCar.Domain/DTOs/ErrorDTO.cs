using System;
namespace DEVinCar.Domain.DTOs
{
    public class ErrorDTO
    {
        public string Error { get; set; }
        public ErrorDTO(string error)
        {
            Error = error;
        }
    }
}

