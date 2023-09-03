using _253504_dmi_Lab5.Collections;
using _253504_dmi_Lab5.Entities;

namespace _253504_dmi_Lab5.Interfaces
{
    interface IStation
    {
        void EnterTariffData(Tariff newTariff);
        void EnterPassengerData(Passenger newPassenger);
        Passenger PassengerInfo(string name);
        Tariff TariffInfo(string destination);
        double TotalTicketPrice();
        MyCustomCollection<Passenger> PassengersByDestination(); 
    }
}