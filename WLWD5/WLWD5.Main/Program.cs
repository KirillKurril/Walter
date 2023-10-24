using WLWD5.Domain;
using WLWD5.Domain.Entities;
using WLWD5.SerializerLib;

namespace WLWD5.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Serializer serializer = new Serializer();

            Computer computer1 = new Computer(
                new Processor("Intel Core i5-10600K", "Intel", "4.10 ГГц", 6),
                new Memory("Corsair", "16 ГБ"),
                new Storage("Samsung", "SSD", "1 ТБ"));

            Computer computer2 = new Computer(
                new Processor("AMD Ryzen 9 5900X", "AMD", "3.70 ГГц", 12),
                new Memory("Kingston", "8 ГБ"),
                new Storage("Western Digital", "HDD", "4 ТБ"));

            Computer computer3 = new Computer(
                new Processor("Apple M1", "Apple", "3.20 ГГц", 8),
                new Memory("G.Skill", "32 ГБ"),
                new Storage("Crucial", "SSD", "500 ГБ"));

            ComputerClub computerClub = new ComputerClub(new List<Computer>() { computer1, computer2, computer3 }, "Ployka");

            serializer.SerializeXML(computerClub.ComputerList, "C:/Walter/WLWD5/Serialization/CompClub.xml");
            /* ComputerClub deserializedByXml = (ComputerClub)serializer.DeSerializeXML("C:/Walter/WLWD5/Serialization/CompClub.xml");
            Console.WriteLine(deserializedByXml);*/

            serializer.SerializeJSON(computerClub.ComputerList, "C:/Walter/WLWD5/Serialization/CompClub.json");
            /* ComputerClub deserializedByJson = (ComputerClub)serializer.DeSerializeJSON("C:/Walter/WLWD5/Serialization/CompClub.json");
             Console.WriteLine(deserializedByJson);*/

            serializer.SerializeByLINQ(computerClub.ComputerList, "C:/Walter/WLWD5/Serialization/CompClub.xlinq");
           /* ComputerClub deserializedByXlinq = (ComputerClub)serializer.DeSerializeByLINQ("C:/Walter/WLWD5/Serialization/CompClub.xlinq");
            Console.WriteLine(deserializedByXlinq);*/
        }
    }
}