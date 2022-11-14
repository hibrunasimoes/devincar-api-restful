using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.ViewModels {
    public class AddressViewModel {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string Cep { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string CityName { get; set; }

        public AddressViewModel(int id,string street,int cityId,string cityName,int number,string complement, string cep) {
            Id = id;
            Street = street;
            CityId = cityId;
            CityName = cityName;
            Number = number;
            Complement = complement;
            Cep = cep;
        }
    }
}
