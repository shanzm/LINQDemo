using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005Union函数_并集
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strList1 = new List<string>() { "a", "b", "c" };
            List<string> strList2 = new List<string>() { "a", "q", "w" };

            ///Union（）方法返回的是多个LINQ查询中的所有成员。
            ///与严格意义上的合并一样，如果相同的成员出现多次，将只能返回一个
            //var listUnion = (from o in strList1 select o).Union(from o in strList2 select o);
            var listUnion = strList1.Union(strList2);
            Array.ForEach(listUnion.ToArray(), o => Console.WriteLine($"两个集合的并集:{o}"));//结果：a,b,c,q,w
            Console.ReadKey();
        }
    }
}
