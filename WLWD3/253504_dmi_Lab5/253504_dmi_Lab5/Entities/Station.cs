using _253504_dmi_Lab5.Interfaces;
using _253504_dmi_Lab5.Modifications;


namespace _253504_dmi_Lab5.Entities
{
    internal class Station : IStation
    {
        private List<Passenger> _passes;
        private List<Tariff> _tariffs;
        private List<Ticket> _tickets;

        public Station() => (_passes, _tariffs, _tickets)
            = (new List<Passenger>(), new List<Tariff>(), new List<Ticket>());

        public delegate void Message(string message);

        public event Message TariffChanged;
        public event Message PassengerChanged;
        public event Message TicketChanged;
        public void OnTariffChange(Tariff tariff)
        {
            TariffChanged?.Invoke($"A new tariff has been added:\n\n{tariff}\n");
        }

        public void OnPassengerChange(Passenger passenger)
        {
            PassengerChanged?.Invoke($"A new passenger has been added:\n\n{passenger}\n");
        }

        public void OnTicketChanged(Ticket ticket)
        {
            TicketChanged?.Invoke(ticket.ToString());
        }

        public void NewTariff(Tariff newTariff)

        {
            _tariffs.Add(newTariff);
            OnTariffChange(newTariff);
        }
        public void NewPassenger(Passenger newPassenger)
        {
            _passes.Add(newPassenger);
            OnPassengerChange(newPassenger);
        }
        public Passenger PassengerInfo(string name)
            => _passes.SingleOrDefault(passenger => passenger.Name == name); 

        public Tariff TariffInfo(string destination) 
            => _tariffs.SingleOrDefault(item => item.Destination == destination);
   
        public double TotalTicketPrice(string name)
            => _tickets.Where(ticket => ticket.Passenger == name).Sum(ticket => ticket.Price);

        public bool BuyTicket(string name, string destination)
        {
            Passenger passenger = _passes.FirstOrDefault(pass => pass.Name == name);
            Tariff tariff = _tariffs.FirstOrDefault(_tariff => _tariff.Destination == destination);

            if (passenger != null && tariff != null) 
            {
                Ticket newTicket = new Ticket(passenger, tariff);
                passenger.Tickets.Add(newTicket);
                _tickets.Add(newTicket);
                return true;
            }
            return false;
        }

        public List<Passenger> PassengersByDestination(string destination)
            => _passes.Where(passenger => passenger.DestCheck(destination)).ToList();

        public override string ToString()
        {
            string output = 
                $"\n\n\t\tStation data:\n" +
                $"\nPassengers list: \n\n{ListToString.ListToStr(_passes)}\n" +
                $"\nTariffs list: \n\n{ListToString.ListToStr(_tariffs)}\n" +
                $"\nTickets list: \n\n{ListToString.ListToStr(_tickets)}\n\n";

            return output;
        }
    }
}
