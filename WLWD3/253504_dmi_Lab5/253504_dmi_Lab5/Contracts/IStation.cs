using _253504_dmi_Lab5.Entities;

namespace _253504_dmi_Lab5.Interfaces
{
    interface IStation
    {
        void NewTariff(Tariff newTariff);
        void NewPassenger(Passenger newPassenger);
        Passenger PassengerInfo(string name);
        Tariff TariffInfo(string destination);
        double TotalTicketPrice(string name);
        List<Passenger> PassengersByDestination(string destination); 
    }
}