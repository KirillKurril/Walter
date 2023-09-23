using _253504_dmi_Lab5.Collections;
using _253504_dmi_Lab5.Entities;
using System;
<<<<<<< HEAD
using System.Net.Sockets;
using static _253504_dmi_Lab5.Entities.Station;
=======
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8

namespace _253504_dmi_Lab5
{
    internal class Program
    {

        public MyCustomCollection<string> tickets = new MyCustomCollection<string>();


        static void Main(string[] args)
        {
<<<<<<< HEAD
            MyCustomCollection<int> arr = new MyCustomCollection<int> { 1, 2, 3, 4, 5 };

            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
            try
            {
                arr.Remove(10);
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            arr = new MyCustomCollection<int>();
            try
            {
                arr.Remove(10);
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

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
=======
            Station RWS = new Station();

            RWS.EnterPassengerData(new Passenger("Vasya", "Antonov"));
            RWS.EnterPassengerData(new Passenger("Alexley", "Winonin"));
            RWS.EnterPassengerData(new Passenger("Victor", "Zakharevich"));
            RWS.EnterPassengerData(new Passenger("Vitalina", "Shishkina"));

            RWS.EnterTariffData(new Tariff("Puhovichy", 3));
            RWS.EnterTariffData(new Tariff("Svetlohorsk", 6));
            RWS.EnterTariffData(new Tariff("Molodechno", 4));
            RWS.EnterTariffData(new Tariff("Lida", 10));
            RWS.EnterTariffData(new Tariff("Luninez", 7));
            RWS.EnterTariffData(new Tariff("Osypovichy", 8));

            RWS.PassengerInfo("Vasya").Print();
            RWS.PassengerInfo("Oleh").Print();

            RWS.TariffInfo("Puhovichy").Print();
            RWS.TariffInfo("Vladyvostok").Print();

            RWS.BuyTicket("Vasya", "Puhovichy");
            RWS.BuyTicket("Vasya", "Svetlohorsk");
            RWS.BuyTicket("Vasya", "Molodechno");
            RWS.BuyTicket("Vasya", "Luninez");

            RWS.BuyTicket("Vitalina", "Puhovichy");

            Console.WriteLine($"\nVasya's debts to the Belarusian railroad are: {RWS.TotalTicketPrice("Vasya")}");

            MyCustomCollection<Passenger> PBD = RWS.PassengersByDestination("Puhovichy");
            Console.WriteLine("Gentlemen and ladies making their way to the Puhovichy:");
            for(int i = 0; i < PBD.Count; ++i)
            {
                Console.WriteLine(PBD[i].Name, " ", PBD[i].Description);
            }
            Console.WriteLine('\n');


            MyCustomCollection<int> collection = new MyCustomCollection<int>();

            collection.Add(14);
            collection.Add(21);
            collection.Add(89);
            collection.Add(44);

            Console.WriteLine("Elements of the collection:");
            collection.Print();

            Console.WriteLine("Current element: " + collection.Current());
            collection.Next();
            Console.WriteLine("Next element: " + collection.Current());

            collection.RemoveCurrent();

            Console.WriteLine("Elements of the collection after removing of the current element");
            collection.Print();

            Console.WriteLine("A number of the elements: " + collection.Count);

            int element = collection[1];
            Console.WriteLine("An element with the index \"1\": " + element);

            collection.Reset();
            Console.WriteLine("Current element after removing the current element: " + collection.Current());

            Console.WriteLine("The collection is empty: " + collection.IsEmty());

            // Удаляем элементы по значению
            collection.Remove(2);
            Console.WriteLine("Elements of the collection after removing of the element with the value 14:");
            collection.Print();
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
        }

       
    }
}