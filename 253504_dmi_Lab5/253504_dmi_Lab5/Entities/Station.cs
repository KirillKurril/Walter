﻿using _253504_dmi_Lab5.Interfaces;
using _253504_dmi_Lab5.Collections;


namespace _253504_dmi_Lab5.Entities
{
    internal class Station : IStation
    {
        private MyCustomCollection<Passenger> _passes;
        private MyCustomCollection<Tariff> _tariffs;
        public Station() => (_passes, _tariffs) = (new MyCustomCollection<Passenger>(), new MyCustomCollection<Tariff>());
        public void EnterTariffData(Tariff newTariff) //новый тариф или данные о тарифе 
        {
            _tariffs.Add(newTariff);
        }
        public void EnterPassengerData(Passenger newPassenger) //новый пассажир или данные о нем 
        {
            _passes.Add(newPassenger);
        }
        public Passenger PassengerInfo(string name) //выдаёт инфу по пассажиру 
        {
            if (!_passes.IsEmty())
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
            if (!_tariffs.IsEmty())
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
        public double TotalTicketPrice() //по данным пассажира выдаёт суммарную стоимость билетов
        {
            return 1;
        }
        public MyCustomCollection<Passenger> PassengersByDestination() //по направлению выдаёт список пассажиров 
        {
            return _passes;
        }
    }
}