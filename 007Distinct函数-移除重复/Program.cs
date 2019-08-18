using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007Distinct函数_移除重复
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strList1 = new List<string>() { "a", "b", "c", "a" };

            var listDistinct = (from o in strList1 select o).Distinct();//其实集合List也是有Distinct()方法的
            Array.ForEach(listDistinct.ToArray(), o => Console.WriteLine($"移除集合中的重复相:{o}"));
            Console.ReadKey();
        }
    }
}
