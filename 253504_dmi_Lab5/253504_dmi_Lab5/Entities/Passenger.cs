namespace _253504_dmi_Lab5.Entities
{
    internal class Passenger
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Tariff[] tariffs;
        public Passenger(string name = "", string description = "", Tariff[] tariffs = null)
        {
            Name = name;
            Description = description;
            this.tariffs = tariffs;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Description: {Description}");
        }
    }
}