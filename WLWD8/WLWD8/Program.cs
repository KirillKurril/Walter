using System.IO.Pipes;
using MyLibrary;

namespace WLWD8
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string fileName = @"..\..\..\..\computers.json";
            Guid randomGuid = new Guid();
            MemoryStream stream = new MemoryStream();
            List<Computer> data = new List<Computer>();
            Func<Computer, bool> filter = (Computer) => { return Computer.Manufacturer == "5"; };
            StreamService<Computer> service = new StreamService<Computer>();
            /*service.Message += (string message) => { Console.WriteLine(message); };*/
            Progress<string> progress = new(Console.WriteLine);

            for (int i = 0; i < 1000; ++i)
            {
                randomGuid = Guid.NewGuid();
                string id = randomGuid.ToString();
                data.Add(new Computer(id, i.ToString(), id[id.Length - 1].ToString()));
            }

            var task1 = service.WriteToStreamAsync(stream, data, progress);
            await Task.Delay(100);
            var task2 = service.CopyFromStreamAsync(stream, fileName, progress);
            Task.WaitAll(task1, task2);


            Console.WriteLine(await service.GetStatisticsAsync(fileName, filter));
            


            
        }
    }
}