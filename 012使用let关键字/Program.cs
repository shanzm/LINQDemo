using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012使用let关键字
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 
            //var groupA = new[] { 3, 4, 5, 6 };
            //var groupB = new[] { 6, 7, 8, 9 };
            //var query = from a in groupA
            //            from b in groupB
            //            where a >= 5 && b >= 8
            //            select new { a, b, sum=a+b };

            //foreach (var item in query)
            //{
            //    //Console.WriteLine($"a={item.a},b={item.b},sum={item.sum}");
            //    Console.WriteLine(item);//注意匿名对象是可以直接打印的
            //}
            //Console.ReadKey();
            #endregion

            #region 使用let语句
            //var groupA = new[] { 3, 4, 5, 6 };
            //var groupB = new[] { 6, 7, 8, 9 };
            //var query = from a in groupA
            //            from b in groupB
            //            let sum = a + b//使用let语句定义一个新的变量，并使用一个运算表达式赋值
            //            where a >= 5 && b >= 8
            //            select new { a, b, sum };

            //foreach (var item in query)
            //{
            //    //Console.WriteLine($"a={item.a},b={item.b},sum={item.sum}");
            //    Console.WriteLine(item);//注意匿名对象是可以直接打印的
            //}
            //Console.ReadKey();
            #endregion

            #region 需要在where语句中使用新的变量，则只能使用let语句

            var groupA = new[] { 3, 4, 5, 6 };
            var groupB = new[] { 6, 7, 8, 9 };
            var query = from a in groupA
                        from b in groupB
                        let sum = a + b//使用let语句定义一个新的变量，并使用一个运算表达式赋值
                        where sum>=13
                        select new { a, b, sum };

            foreach (var item in query)
            {
                //Console.WriteLine($"a={item.a},b={item.b},sum={item.sum}");
                Console.WriteLine(item);//注意匿名对象是可以直接打印的
            }
            Console.ReadKey();
            #endregion
        }
    }
}
