using _253504_dmi_Lab5.Collections;

namespace _253504_dmi_Lab5.Entities
{
    internal class Passenger
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public MyCustomCollection<Tariff> Tariffs;
        public Passenger(string name = "", string description = "", MyCustomCollection<Tariff> tariffs = null)
        {
            Name = name;
            Description = description;
            Tariffs = tariffs ?? new MyCustomCollection<Tariff>();
    }
        public override string ToString()
        {
            string str1 = $"Name: {Name}\nDescription: {Description}\n";

            return (!Tariffs.IsEmpty()) ? str1 + $"Treir tariffs:\n{Tariffs.ToString()}\n" : str1 + "No tariffs\n";
        }

        public double TotalCost()
        {
            double totalCost = 0.0;
            for (int i = 0; i < Tariffs.Count; ++i)
            {
                totalCost += Tariffs[i].Price;
            }
            return totalCost;
        }

        public bool DestCheck(string destination)
        {
            for (int i = 0; i < Tariffs.Count; ++i)
            {
                Tariff tariff = Tariffs[i];
                if (tariff.Destination == destination)
                    return true;
            }
            return false;
        }
    }
}