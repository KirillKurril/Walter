using _253504_dmi_Lab5.Interfaces;
using _253504_dmi_Lab5.Collections;
using System;


namespace _253504_dmi_Lab5.Entities
{
    internal class Station : IStation
    {
        private MyCustomCollection<Passenger> _passes;
        
        private MyCustomCollection<Tariff> _tariffs;
<<<<<<< HEAD
        private MyCustomCollection<Ticket> _tickets;

        public Station() => (_passes, _tariffs, _tickets)
            = (new MyCustomCollection<Passenger>(), new MyCustomCollection<Tariff>(), new MyCustomCollection<Ticket>());

        public delegate void Message(string message);

        public event Message TariffChanged;
        public event Message PassengerChanged;
        public event Message TicketChanged;
        public void OnTariffChange(Tariff tariff)
        {
            TariffChanged?.Invoke($"A new tariff has been added:\n\n{tariff.ToString()}\n");
        }

        public void OnPassengerChange(Passenger passenger)
        {
            PassengerChanged?.Invoke($"A new passenger has been added:\n\n{passenger.ToString()}\n");
        }

        public void OnTicketChanged(Ticket ticket)
        {
            TicketChanged?.Invoke(ticket.ToString());
        }
=======


        public Station() => (_passes, _tariffs) = (new MyCustomCollection<Passenger>(), new MyCustomCollection<Tariff>());

>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8

        public void EnterTariffData(Tariff newTariff) //новый тариф или данные о тарифе 

        {
            _tariffs.Add(newTariff);
            OnTariffChange(newTariff);
        }

        public void EnterPassengerData(Passenger newPassenger) //новый пассажир или данные о нем 

        {
            _passes.Add(newPassenger);
            OnPassengerChange(newPassenger);
        }

        public Passenger PassengerInfo(string name) //выдаёт инфу по пассажиру 

        {
            if (!_passes.IsEmpty())
            {
                for (int i = 0; i < _passes.Count; ++i)
                {
                    Passenger pass = _passes[i];
                    if (pass.Name == name)
                    {
                        return pass;
                    }
                }
            }
            return new Passenger();
        }

        public Tariff TariffInfo(string destination) //выдаёт инфу по тарифу 

        {
            if (!_tariffs.IsEmpty())
            {
                for (int i = 0; i < _tariffs.Count; ++i)
                {
                    Tariff tariff = _tariffs[i];
                    if (tariff.Destination == destination)
                    {
                        return tariff;
                    }
                }
            }
            return new Tariff();
        }
        public double TotalTicketPrice(string name) //по данным пассажира выдаёт суммарную стоимость билетов
        {
<<<<<<< HEAD
            if (!_passes.IsEmpty())
=======
            if (!_passes.IsEmty())
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
            {
                for (int i = 0; i < _passes.Count; ++i)
                {
                    Passenger pass = _passes[i];
                    if (pass.Name == name)
                    {
                        return pass.TotalCost();
                    }
                }
            }
            return 0;
        }

        public bool BuyTicket(string name, string destination)
        {
<<<<<<< HEAD
            if (!_passes.IsEmpty() && !_tariffs.IsEmpty())
=======
            if (!_passes.IsEmty() && !_tariffs.IsEmty())
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
            {
                for (int i = 0; i < _passes.Count; ++i)
                {
                    Passenger pass = _passes[i];
                    if (pass.Name == name)
                    {
                        for (int j = 0; j < _tariffs.Count; ++j)
                        {
                            Tariff tariff = _tariffs[j];
                            if (tariff.Destination == destination)
                            {
<<<<<<< HEAD
                                pass.Tariffs.Add(tariff);
                                Ticket newTicket = new Ticket(pass, tariff);
                                _tickets.Add(newTicket);
                                OnTicketChanged(newTicket);
=======
                                pass.tariffs.Add(tariff);
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
                            }
                        }
                    }
                }
            }
<<<<<<< HEAD

=======
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
            return false;
        }

        public MyCustomCollection<Passenger> PassengersByDestination(string destination) //по направлению выдаёт список пассажиров 
        {
            MyCustomCollection<Passenger> passengers = new MyCustomCollection<Passenger>();
            for (int i = 0; i < _passes.Count; ++i)
            {
                Passenger pass = _passes[i];
                if (pass.DestCheck(destination))
                    passengers.Add(pass);

            }
            return passengers;
<<<<<<< HEAD
        }

        public override string ToString()
        {
            string output = 
                $"\n\n\t\tStation data:\n" +
                $"\nPassengers list: \n\n{_passes.ToString()}\n" +
                $"\nTariffs list: \n\n{_tariffs.ToString()}\n" +
                $"\nTickets list: \n\n{_tickets.ToString()}\n\n";

            return output;
=======
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
        }
    }
}
