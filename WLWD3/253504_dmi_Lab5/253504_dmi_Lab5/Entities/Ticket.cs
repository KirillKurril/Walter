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
        public string Passenger { get; set; }

        public string Destination { get; set; }

        public double Price { get; set; }

        public Ticket(Passenger passenger, Tariff tariff) 
            => (Passenger, Destination, Price) = (passenger.Name, tariff.Destination, tariff.Price);
     
        public override string ToString()
        {
            return ($"Destination: {Destination}\n" +
                $"Passenger name: {Passenger}\n" +
                $"Ticket price: {Price}\n");
        }
    }
}
