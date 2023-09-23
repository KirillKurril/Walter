using System;
using _253504_dmi_Lab5.Collections;

namespace _253504_dmi_Lab5.Entities
{
    internal class Journal
    {
        private MyCustomCollection<string> passesChanges;
        private MyCustomCollection<string> tariffsChanges;

        public Journal() => (passesChanges, tariffsChanges) = (new MyCustomCollection<string>(), new MyCustomCollection<string>());


       public void TariffChangeHandler(string str)
        {
            tariffsChanges.Add(str);
        }

        public void PassengerChangeHandler(string str)
        {
            passesChanges.Add(str);
        }

        public override string ToString() 
        {
            return $"\n\nJournal Data:\n\n\tPassengers changes data:\n\n{passesChanges.ToString()}\tTariffs changes data:\n\n{tariffsChanges.ToString()}";
        }
    }
}
