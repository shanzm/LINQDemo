using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015关于Enumerable中的方法
{
    class Program
    {
        static void Main(string[] args)
        {
            ///以下的所有方法都可以按照静态方法调用：如：Eumerable.First(groupA)....
            var groupA = new[] { 1, 2, 3, 4, 5, 5, 6, 6, 10 };

            var firstElement = groupA.First();//取第一个元素

            var MaxElement = groupA.Max();//取最大值

            var MinElement = groupA.Min();//取最小值

            var averageElement = groupA.Average();//取最平均值

            var SumElement = groupA.Sum();//所有元素求和

            var CountElement = groupA.Count();//元素个数

            var CountOddElement = groupA.Count(n => n % 2 != 0);//使用lambda作为Count()参数，计算容器中的奇数个数

            var indexElement = groupA.ElementAt(8);//根据下标取元素，下标8即第9个元素：10

            var lastElement = groupA.Last();//取最后一个元素

            var IsEqual = groupA.SequenceEqual(new[] { 1, 2, 3, 4, 5, 5, 6, 6, 10 });//判断两个容器是否相同

            var singleElement = (new[] { 99 }).Single();//判断容器中是否只有一个元素，若是则反正这个元素，否则报错

            Array.ForEach(groupA.Reverse().ToArray(), n => Console.Write(n + " "));//元素倒序

            var anyElement = groupA.Any();//判断容器是否为空，不为空则true

            var IsAnyEven = new int[] { 1, 3, 4 }.Any(n => (n % 2) == 0);//是否有一部分元素满足是偶数,返回值是true

            var IsAllEven = new int[] { 2, 4 }.All(n => (n % 2) == 0);//若全是偶数则为true



            Console.WriteLine("结果" + CountOddElement);


            Console.ReadKey();
        }
    }
}
