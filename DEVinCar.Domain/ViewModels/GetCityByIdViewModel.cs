namespace DEVinCar.Domain.ViewModels;

public class GetCityByIdViewModel
{
    public int cityId { get; set; }
    public string cityName { get; set; }
    public int stateId { get; set; }
    public string stateName { get; set; }
    public string stateInitials { get; set; }

    public GetCityByIdViewModel(int cityId, string cityName, int stateId, string stateName, string stateInitials)
    {
        this.cityId = cityId;
        this.cityName = cityName;
        this.stateId = stateId;
        this.stateName = stateName;
        this.stateInitials = stateInitials;
    }
}