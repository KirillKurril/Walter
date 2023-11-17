using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool HasAward { get; set; }
        public Employee(string name, int age, bool hasAward)
            => (Name, Age, HasAward) =(name, age, hasAward);

    }
}
