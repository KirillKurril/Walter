using _253504_dmi_Lab5.Collections;
using _253504_dmi_Lab5.Entities;
using System;
using System.Net.Sockets;
using static _253504_dmi_Lab5.Entities.Station;

namespace _253504_dmi_Lab5
{
    internal class Program
    {

        public MyCustomCollection<string> tickets = new MyCustomCollection<string>();


        static void Main(string[] args)
        {
            Station station = new Station();
            Journal journal = new Journal();
            Program program = new Program();

            station.TariffChanged += journal.TariffChangeHandler;
            station.PassengerChanged += journal.PassengerChangeHandler;
            station.TicketChanged += (string message) => { program.tickets.Add(message); };

            station.EnterPassengerData(new Passenger("pass 1", "descr 1"));
            station.EnterPassengerData(new Passenger("pass 2", "descr 2"));
            station.EnterPassengerData(new Passenger("pass 3", "descr 3"));

            station.EnterTariffData(new Tariff("dest 1", 1));
            station.EnterTariffData(new Tariff("dest 2", 2));
            station.EnterTariffData(new Tariff("dest 3", 3));

            Console.WriteLine(journal.ToString());

            station.BuyTicket("pass 1", "dest 1");
            station.BuyTicket("pass 2", "dest 2");
            station.BuyTicket("pass 3", "dest 3");

            Console.WriteLine("\n\nTicket purchase log:\n\n" + program.tickets.ToString());
            Console.WriteLine(station.ToString());
        }

       
    }
}