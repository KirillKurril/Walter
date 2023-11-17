using _253504_dmi_Lab5.Modifications;

namespace _253504_dmi_Lab5.Entities
{
    internal class Passenger
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Ticket> Tickets;
        public Passenger(string name = "", string description = "")
            => (Name, Description, Tickets) = (name, description, new List<Ticket>());

        public double TotalCost()
            => Tickets.Sum(ticket => ticket.Price);

        public bool DestCheck(string destination)
            => Tickets.Any(ticket => ticket.Destination == destination);

        public override string ToString()
        {
            string str1 = $"Name: {Name}\nDescription: {Description}\n";

            return (Tickets.Any()) ? str1 + $"Treir Tickets:\n{ListToString.ListToStr(Tickets)}\n" : str1 + "No Tickets\n";
        }
    }
}