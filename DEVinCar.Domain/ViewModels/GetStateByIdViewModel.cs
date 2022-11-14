namespace DEVinCar.Domain.ViewModels
{
    public class GetStateByIdViewModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateInitials { get; set; }

        public GetStateByIdViewModel(int id, string name, string initials)
        {
            StateId = id;
            StateName = name;
            StateInitials = initials;
        }

    }
}
