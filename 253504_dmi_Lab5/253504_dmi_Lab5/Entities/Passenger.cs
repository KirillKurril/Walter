using _253504_dmi_Lab5.Collections;

namespace _253504_dmi_Lab5.Entities
{
    internal class Passenger
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public MyCustomCollection<Tariff> tariffs;

        public Passenger(string name = "", string description = "", MyCustomCollection<Tariff> tariffs = null)
        {
            Name = name;
            Description = description;
            this.tariffs = tariffs ?? new MyCustomCollection<Tariff>();
        }

        public bool DestCheck(string destination)
        {
            for(int i = 0; i < tariffs.Count; ++i)
            {
                Tariff tariff = tariffs[i];
                if (tariff.Destination == destination)
                    return true;
            }
            return false;
        }

        public void Print()
        {
            if (!tariffs.IsEmty())
            {
                string destinations = "";
                for (int i = 0; i < tariffs.Count; ++i)
                {
                    Tariff tariff = tariffs[i];
                    destinations += tariff.Destination + " ";
                }
                Console.WriteLine($"Name: {Name}, Description: {Description}, Tickets: {destinations}");
            }
        }
        public double TotalCost()
        {
            double totalCost = 0.0;
            for (int i = 0; i < tariffs.Count; ++i)
            {
            totalCost += tariffs[i].Price;
            }
            return totalCost;
        }
    }
}