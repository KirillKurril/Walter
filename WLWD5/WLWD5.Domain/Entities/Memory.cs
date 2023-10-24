using System.Reflection;

namespace WLWD5.Domain.Entities
{
    public class Memory
    {
        public string? Manufacturer { get; set; }
        public string? Capacity { get; set; }

        public Memory() { }
        public Memory(string manufacturer = "not stated", string capacity = "not stated")
            => (Manufacturer, Capacity) = (manufacturer, capacity);
        public override string ToString()
        {
            return $"\n\tCapacity: {Capacity}" +
                $"\n\tManufacturer: {Manufacturer}";
        }
    }
}
