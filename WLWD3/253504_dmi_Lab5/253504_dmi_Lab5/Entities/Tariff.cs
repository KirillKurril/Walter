namespace _253504_dmi_Lab5.Entities
{
    internal class Tariff
    {
        public string Destination { get; set;}
        public double Price { get; set;}
        public Tariff(string destination = "", double price = 0.0) => (Destination, Price) = (destination, price);

        public override string ToString()
        {
            return $"Destination: {Destination}\nPrice: {Price}";
        }
    }
}