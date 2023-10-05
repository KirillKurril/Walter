using _253504_dmi_Lab5.Modifications;

namespace _253504_dmi_Lab5.Entities
{
    internal class Journal
    {
        private List<string> passesChanges;
        private List<string> tariffsChanges;

        public Journal() => (passesChanges, tariffsChanges) = (new List<string>(), new List<string>());


       public void TariffChangeHandler(string str) => tariffsChanges.Add(str);

        public void PassengerChangeHandler(string str) => passesChanges.Add(str);

        public override string ToString() 
        {
            return $"\n\nJournal Data:\n\n\tPassengers changes data:" +
                $"\n\n{ListToString.ListToStr(passesChanges)}" +
                $"\tTariffs changes data:" +
                $"\n\n{ListToString.ListToStr(tariffsChanges)}";
        }
    }
}
