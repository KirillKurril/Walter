namespace _253504_dmi_Lab5.Entities
{
    internal class Tariff
    {
        public string Destination { get; set;}

        public double Price { get; set;}

        public Tariff(string destination = "", double price = 0.0) => (Destination, Price) = (destination, price);

<<<<<<< HEAD
        public override string ToString()
        {
            return $"Destination: {Destination}\nPrice: {Price}";
=======
        public void Print()
        {
            Console.WriteLine($"Destination: {Destination}, Price: {Price}");
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
        }
    }
}