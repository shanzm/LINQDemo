using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _000数组的ForEach函数
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[] { 2, 4, 6, 8, 10 };
            //foreach (var item in myArray)
            //{
            //    Console.WriteLine(item);
            //}
            Array.ForEach(myArray, n => Console.WriteLine($"我是：{n}"));
            //注意ForEach()是Array类的静态方法，
            //主要用来对数组的每一个成员进行操作，比如，全部转换为写小写
            //第一个参数是一个数组（若你的目标对象是一个List，可以ToArray（））
            //第二个参数是一个无返回值的委托：Action
            Console.ReadKey();
        }
    }
}
