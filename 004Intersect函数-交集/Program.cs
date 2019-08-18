using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004Intersect函数_交集
{
    class Program
    {
        private static readonly object listDiff;

        static void Main(string[] args)
        {
            List<string> strList1 = new List<string>() { "a", "b", "c" };
            List<string> strList2 = new List<string>() { "a", "q", "w" };

            var listIntersection = (from o in strList1 select o).Intersect(from o in strList2 select o);
            Array.ForEach(listIntersection.ToArray(), o => Console.WriteLine($"两个集合的交集:{o}"));
            Console.ReadKey();
        }
    }
}
