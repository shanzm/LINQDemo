using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002使用ofType筛选数据
{
    class Program
    {
        /// <summary>
        /// 精通C#--12.5.3：使用ofType<T>筛选数据
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 1, 2, 3, 5, 8, 'a', "bb" });

            var myInts = myStuff.OfType<int>();

            Array.ForEach(myInts.ToArray(), n => Console.WriteLine(n + " "));
            Console.ReadKey();

        }
    }
}
