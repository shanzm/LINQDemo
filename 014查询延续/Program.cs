using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014查询延续
{
    class Program
    {
        static void Main(string[] args)
        {
            //类似SQL中的子查询嵌套
            var groupA = new[] { 3, 4, 5, 6 };
            var groupB = new[] { 4, 5, 6, 7 };

            var query = from a in groupA
                        join b in groupB on a equals b
                        into groupAandB//连接groupA和groupB，并命名为groupAandB,从而实现查询继续
                        from c in groupAandB
                        select c;
            //注意这样是不可以的：var query = from c in (from a in groupA join b in groupA on a equals b select) select c;
            Array.ForEach(query.ToArray(), n => Console.Write(n + " "));
            Console.ReadKey();
        }
    }
}
