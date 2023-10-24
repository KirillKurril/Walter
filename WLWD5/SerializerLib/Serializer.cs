using System.IO;
using System.Reflection.PortableExecutable;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Serialization;
using WLWD5.Domain.Entities;
using WLWD5.Domain.Interfaces;
using System.Xml.Linq;
using System.Xml.XPath;

namespace WLWD5.SerializerLib
{
    public class Serializer : ISerializer<Computer>
    {
        public IEnumerable<Computer> DeSerializeByLINQ(string fileName)
        {
            string xml;
            using (StreamReader reader = new StreamReader(fileName))
            {
                xml = reader.ReadToEnd();
            }
            XDocument doc = XDocument.Parse(xml);

            var computerList = doc.XPathSelectElements("//Computer").Select(compElement =>
            {
                var processorElement = compElement.XPathSelectElement("Processor");
                Processor processor = new Processor(
                    processorElement.XPathSelectElement("Model").Value,
                    processorElement.XPathSelectElement("Manufacturer").Value,
                    processorElement.XPathSelectElement("ClockSpeed").Value,
                    int.Parse(processorElement.XPathSelectElement("Cores").Value)
                );

                var memoryElement = compElement.XPathSelectElement("Memory");
                Memory ram = new Memory(
                    memoryElement.XPathSelectElement("Manufacturer").Value,
                    memoryElement.XPathSelectElement("Capacity").Value
                );

                var storageElement = compElement.XPathSelectElement("Storage");
                Storage drive = new Storage(
                    storageElement.XPathSelectElement("Manufacturer").Value,
                    storageElement.XPathSelectElement("Type").Value,
                    storageElement.XPathSelectElement("Capacity").Value
                );

                return new Computer(processor, ram, drive);
            });

            return new ComputerClub(computerList.ToList());
        }
        public IEnumerable<Computer> DeSerializeJSON(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string json = reader.ReadToEnd();
                List<Computer> computerList = JsonConvert.DeserializeObject<List<Computer>>(json);
                return new ComputerClub(computerList);
            }
        }

        public IEnumerable<Computer> DeSerializeXML(string fileName)
        {
           XmlSerializer serializer = new XmlSerializer(typeof(List<Computer>));
           using (StreamReader file = new StreamReader(fileName))
           {
               return new ComputerClub((List<Computer>)serializer.Deserialize(file));
           }
        }

        public void SerializeByLINQ(IEnumerable<Computer> computerCollection, string fileName)
        {
            XDocument doc = new XDocument(
                new XElement("ComputerClub",
                    computerCollection.Select(comp =>
                        new XElement("Computer",
                            new XElement("Processor",
                                new XElement("Model", comp.Processor.Model),
                                new XElement("Manufacturer", comp.Processor.Manufacturer),
                                new XElement("ClockSpeed", comp.Processor.ClockSpeed),
                                new XElement("Cores", comp.Processor.NumberOfCores)
                               ),
                            new XElement("Memory",
                                new XElement("Manufacturer", comp.RAM.Manufacturer),
                                new XElement("Capacity", comp.RAM.Capacity)
                            ),
                            new XElement("Storage",
                                new XElement("Manufacturer", comp.Drive.Manufacturer),
                                new XElement("Type", comp.Drive.Type),
                                new XElement("Capacity", comp.Drive.Capacity)
                            )
                           )
                       )
                   )
               );

            doc.Save(fileName);
        }

        public void SerializeJSON(IEnumerable<Computer> computerCollection, string fileName)
        {
            string json = JsonConvert.SerializeObject(computerCollection.ToList());
            File.WriteAllText(fileName, json);
        }

        public void SerializeXML(IEnumerable<Computer> computerList, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Computer>));
            using (FileStream file = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(file, computerList);
            }
        }
    }
}