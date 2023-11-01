using System.Reflection;

namespace Lab6
{
    class program
    {
        static void Main(string[] args) 
        {
            string Path = @"C:\Uni\walter\WLWD6\json\DataList.json";

            List<Employee> employees = new List<Employee>()
            {
                new Employee("Ivan", 42, false),
                new Employee("Aleksandr", 37, false),
                new Employee("Viktor  ", 29, true),
                new Employee("Elena", 43, false),
                new Employee("Anna", 35, true),
            };


            Assembly assembly = Assembly.LoadFrom("MyLibrary.dll");
            Type? t = assembly.GetType("MyLibrary.FileService`1").MakeGenericType(typeof(Employee));
            
            var obj = Activator.CreateInstance(t);
            MethodInfo? saveData = t.GetMethod("SaveData");
            MethodInfo? readFile = t.GetMethod("ReadFile");


            saveData?.Invoke(obj, new object[] { employees, Path });
            IEnumerable<Employee> readList = (IEnumerable<Employee>)readFile?.Invoke(obj, new object[] { Path });

            Console.WriteLine("Obtained data :\n");
            foreach (var employee in readList)
            {
                Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Is on vacation: {employee.HasAward}");
            }

        }
    }
}