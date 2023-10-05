using _253504_dmi_Lab5.Collections;

namespace _253504_dmi_Lab5.Entities
{
    internal class Passenger
    {
        public string Name { get; set; }

        public string Description { get; set; }

<<<<<<< HEAD
        public MyCustomCollection<Tariff> Tariffs;
=======
        public MyCustomCollection<Tariff> tariffs;

>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
        public Passenger(string name = "", string description = "", MyCustomCollection<Tariff> tariffs = null)
        {
            Name = name;
            Description = description;
<<<<<<< HEAD
            Tariffs = tariffs ?? new MyCustomCollection<Tariff>();
    }
        public override string ToString()
        {
            string str1 = $"Name: {Name}\nDescription: {Description}\n";

            return (!Tariffs.IsEmpty()) ? str1 + $"Treir tariffs:\n{Tariffs.ToString()}\n" : str1 + "No tariffs\n";
=======
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
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
        }

        public double TotalCost()
        {
<<<<<<< HEAD
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
=======
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
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
        }
    }
}