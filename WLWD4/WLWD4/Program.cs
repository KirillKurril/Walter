using System.IO.Enumeration;
using WLWD4.Entities;

namespace WLWD4
{
    internal class Program
    {
        static void DataPrint(Dictionary<string, List<Computer>> fileData)
        {
            foreach (var file in fileData)
            {
                Console.WriteLine($"\nFile name: {file.Key}\n\nFile data:");
                foreach (var dataList in file.Value)
                    Console.WriteLine(dataList.ToString());
            }
        }
        static void Main(string[] args)
        {
            string mainDir = @"C:\Walter\WLWD4\WLWD4";
            string curDir = Path.Combine(mainDir, "dmitruk_Lab4");
            FileService fileHandler = new FileService(curDir);


            fileHandler.DirectoryInit();
            Dictionary<string, string> fileInfo = fileHandler.GetFilesInfo();
            Console.WriteLine("\nList of files in the current directory:\n\n");
            foreach (var file in fileInfo)
                Console.WriteLine($"File name: {file.Key}, file extention: {file.Value}");


            fileHandler.FillFiles();
            Console.WriteLine("\n\nFiles are filled\n\n");
            Dictionary<string, List<Computer>> fileData = fileHandler.GetFilesData();
            DataPrint(fileData);

           

            Console.WriteLine("\n\nFile data is sorted\n\n");
            fileHandler.Sort(fileData);
            DataPrint(fileData);

        }
        
    }
    
}
