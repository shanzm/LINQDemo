using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006Concat函数_合并多个集合
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strList1 = new List<string>() { "a", "b", "c" };
            List<string> strList2 = new List<string>() { "a", "q", "w" };

            ///与Union（）方法不同的是返回的是不排出重复
            var listConcat = (from o in strList1 select o).Concat(from o in strList2 select o);
            Array.ForEach(listConcat.ToArray(), o => Console.WriteLine($"两个集合的合并（不排除重复）:{o}"));
            Console.ReadKey();
        }
    }
}
