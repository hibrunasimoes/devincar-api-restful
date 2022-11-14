namespace DEVinCar.Domain.Models {
    public class State {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }

        public virtual List<City> Cities { get; set; }

        public State(int id, string name, string initials)
        {
            Id = id;
            Name = name;
            Initials = initials;
        }
    }
}
