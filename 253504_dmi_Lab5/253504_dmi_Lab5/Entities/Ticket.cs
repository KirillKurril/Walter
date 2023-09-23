using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _253504_dmi_Lab5.Entities
{
    internal class Ticket
    {
        public Passenger Passenger { get; set; }

        public Tariff Tariff { get; set; }

        public Ticket(Passenger passenger, Tariff tariff) => (Passenger, Tariff) = (passenger, tariff);
     
        public override string ToString()
        {
            return ($"Destination: {Tariff.Destination}\n" +
                $"Passenger name: {Passenger.Name}\n" +
                $"Ticket price: {Tariff.Price}\n");
        }
    }
}
