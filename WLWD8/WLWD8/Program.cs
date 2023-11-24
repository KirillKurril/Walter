using MyLibrary;

namespace WLWD8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            StreamService<int> ss = new StreamService<int>();
            int[] arr = new int[10];
            ss.WriteToStreamAsync(new MemoryStream(new byte[] { }), arr);
            Console.WriteLine("А МЕНЯ ЕБАЛИ");
        }
    }
}