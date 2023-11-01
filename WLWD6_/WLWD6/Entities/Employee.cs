using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLWD6.Entities
{
    internal class Employee
    {
        public int Age { get; set; }
        public bool On_vacation { get; set; }
        public string Name { get; set; }
        public Employee(string name = "No name", int salary = 0, bool on_vacation = false)
            => (Name, Age, On_vacation) = (name, salary, on_vacation);
    }
}
