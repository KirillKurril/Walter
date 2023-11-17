using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLWD4.Entities
{
    internal class MyCustomComparer<T> : IComparer<T> where T : Computer
    {
        public int Compare(T? x, T? y) => string.Compare(x.Name, y.Name);

    }
}
