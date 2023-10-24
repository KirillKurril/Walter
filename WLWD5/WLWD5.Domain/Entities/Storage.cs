using System.Reflection;

namespace WLWD5.Domain.Entities
{
    public class Storage
    {
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string Capacity { get; set; }

        public Storage() { }

        public Storage(string manufacturer = "not stated", string type = "not stated", string capacity = "not stated")
            => (Manufacturer, Type, Capacity) = (manufacturer, type, capacity);
        public override string ToString()
        {
            return $"\n\tType: {Type}" +
                $"\n\tManufacturer: {Manufacturer}" +
                $"\n\tCapacity: {Capacity}\n";
        }
    }
}
