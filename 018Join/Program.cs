using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _018Join
{
    internal class Program
    {
        private static void Main(string[] args)
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

            //查询语法
            var query1 = from c in customers
                         join p in purchase on c.Id equals p.CustomerId//注意使用：equals，而不是:"=="
                         select new { c.Name, p.Price };
            query1.WriteLineAll();

            Console.WriteLine("----------------------------------");

            //流式语法（不如直接使用linq查询语法简洁）
            //var query2 = customers.Join(purchase, c => c.Id, p => p.CustomerId,(c, p) => new { c.Name, p.Price });
            //换行写，更便于阅读
            //注意Join()函数只能进行等值连接，所以其实我们也看到了，我们并没有写类似“c.Id equals p.CustomerId”这样的语句
            var query2 = customers.Join(
                purchase,//连接对象
                c => c.Id,//左表字段
                p => p.CustomerId,//右表字段
                (c, p) => new { c.Id, c.Name, p.Price }//查询
                );
            query2.WriteLineAll();
            Console.ReadKey();

            //todo:
            //自定义扩展方法，对IEnumber<T>添加扩展方法
            //实现左右连接和全连接
            // purchase.LeftJoin()
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
