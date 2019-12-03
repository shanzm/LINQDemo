using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003Except函数_比较不同
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strList1 = new List<string>() { "a", "b", "c" };
            List<string> strList2 = new List<string>() { "a", "q", "w" };

            // var listDiff = (from o in strList1 select o).Except(from o in strList2 select o);
            var listDiff = strList1.Except(strList2);
            Array.ForEach(listDiff.ToArray(), o => Console.WriteLine($"第一个集合有而第二个集合没有的对象:{o}"));//结果：b，c
            Console.ReadKey();
        }
    }
}
