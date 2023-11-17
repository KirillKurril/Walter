using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_dmi_Lab5.Modifications
{
    internal class ListToString
    {
       public static string ListToStr<T>(List<T> list)
        {
            if (list.Any())
            {
                StringBuilder outstr = new StringBuilder();
                foreach (var item in list)
                {
                    outstr.AppendLine(item.ToString());
                }
                return outstr.ToString();
            }

            return "The structure is empty";
        }
    }
}
