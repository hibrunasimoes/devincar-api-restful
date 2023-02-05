using System;
namespace DEVinCar.Domain.Exceptions
{
	public class IsExistsException : Exception
	{
        public IsExistsException(string error) : base(error)
        {

        }
    }
}

