using System.Runtime.Intrinsics.Arm;

namespace WLWD5.Domain.Entities
{
    public class Processor
    {
        public string? Model { get; set; }
        public string? Manufacturer { get; set; }
        public string? ClockSpeed { get; set; }
        public int? NumberOfCores { get; set; }

        Processor() { }
        public Processor(string model = "not stated", string manufacturer = "not stated", string clockSpeed = "not stated", int numberOfCores = -1)
            => (Model, Manufacturer, ClockSpeed, NumberOfCores) = (model, manufacturer, clockSpeed, numberOfCores);
        public override string ToString()
        {
            return $"\n\tModel: {Model}" +
                $"\n\tManufacturer: {Manufacturer}" +
                $"\n\tClockSpeed: {ClockSpeed}" +
                $"\n\tNumberOfCores: {NumberOfCores}\n";
        }
    }
}
