using System.Reflection;
using WLWD6.Entities;

namespace _253504_dmi_Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee("Ivan", 42, true),
                new Employee("Aleksandr", 37, false),
                new Employee("Viktor  ", 29, false),
                new Employee("Elena", 43, true),
                new Employee("Anna", 35, true),
            };

            string path = @"C:\Uni\walter\WLWD6\json\DataList.json";

            Assembly assembly = Assembly.LoadFrom("MyLibrary.dll");

            Type type = assembly.GetType("MyLibrary.FileService`1").MakeGenericType(typeof(Employee));
            var obj = Activator.CreateInstance(type);
            MethodInfo saveData = type.GetMethod("SaveData");
            MethodInfo readFile = type.GetMethod("ReadFile");

            saveData?.Invoke(obj, new object[] { employees, path , Path.Combine(path, "DataList.json")});
            IEnumerable<Employee> readList = (IEnumerable<Employee>)readFile?.Invoke(obj, new object[]{path});

            Console.WriteLine("Obtained data :\n");
            foreach (var employee in readList)
            {
                Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Is on vacation: {employee.On_vacation}");
            }
        }
    }
}