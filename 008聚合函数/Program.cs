using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008聚合函数
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] intArray = { 1, 2, 3, 4, 5, 5 };
            //不同的聚合示例
            Console.WriteLine("Max :{0}", (from t in intArray select t).Max());
            Console.WriteLine("Min :{0}", (from t in intArray select t).Min());
            Console.WriteLine("Avarage :{0}", (from t in intArray select t).Average());
            Console.WriteLine("Sum :{0}", (from t in intArray select t).Sum());
            Console.WriteLine("5 出现的次数:{0}", (from t in intArray where t == 5 select t).Count());
            Console.ReadKey();
        }
    }
}
