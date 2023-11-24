namespace MyLibrary
{
    public class Computer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; private set; }
        public Computer(string id, string name, string manufacturer)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
        }
    }
}
