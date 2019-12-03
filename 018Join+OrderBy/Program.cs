using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _018Join_OrderBy
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new[]
               {
                new {Id=1,Name="shanzm1",Gender="male"},
                new {Id=2,Name="shanzm2",Gender="female"},
                new {Id=3,Name="shanzm3",Gender="male"}
            };

            var purchase = new[]
            {
                new {Id="001",CustomerId=1,Description="this is shanzm1's shopping list",Price=100,DateTime="2019-12-1 21:01:28"},
                new {Id="002",CustomerId=2,Description="this is shanzm2's shopping list",Price=200,DateTime="2019-12-2 21:01:28"},
                new {Id="003",CustomerId=3,Description="this is shanzm3's shopping list",Price=300,DateTime="2019-12-3 21:01:28"},
                new {Id="004",CustomerId=1,Description="this is shanzm1's shopping list",Price=400,DateTime="2019-12-4 21:01:28"},
            };

            //注意查询语法和流式查询在查询结果之前添加其他子句的方式，比如orderby

            //查询语法
            var query1 = from c in customers
                         join p in purchase on c.Id equals p.CustomerId
                         orderby p.Price
                         select new { c.Name, p.Price };
            query1.WriteLineAll();

            Console.WriteLine("----------------------------------");

            //流式语法
            var query2 = customers.Join(
                purchase,
                c => c.Id,
                p => p.CustomerId,
                (c,p)=>new { c.Name, p.Price }
                ).OrderBy(x=>x.Price );
            query2.WriteLineAll();
            Console.ReadKey();


        }
    }

    public static class Extender
    {
        public static void WriteLineAll<T>(this IEnumerable<T> list)
        {
            Array.ForEach(list.ToArray(), n => Console.WriteLine(n));
        }
    }
}