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
            ///标准查询运算符
            ///以下的所有方法都可以按照静态方法调用：如：Eumerable.First(groupA)....
            var groupA = new[] { 1, 2, 3, 4, 5, 5, 6, 6, 10, 0 };

            var orderByElement = groupA.OrderBy(n => n);//升序排序：若是数组类型则等价于.Sort();
            var orderByDescendingElement = groupA.OrderByDescending(n => n);//降序排列
            //注意如果需要多个排序条件，可以接着使用：.ThenBy(Func)
            Array.ForEach(orderByDescendingElement.ToArray(), n => Console.WriteLine("\r\n" + n + " "));


            var firstElement1 = groupA.First();//取第一个元素,
                                               //若没有则引发异常:InvalidOperationException 异常
            var firstElement2 = groupA.FirstOrDefault();//取第一个元素,
                                                        //若没有则：对于可以为null的对象，默认值为null，对于不能为null的对象，如int，默认值为0

            var MaxElement = groupA.Max();//取最大值

            var MinElement = groupA.Min();//取最小值

            var averageElement = groupA.Average();//取最平均值

            var SumElement = groupA.Sum();//所有元素求和

            var CountElement = groupA.Count();//元素个数

            var CountOddElement = groupA.Count(n => n % 2 != 0);//使用lambda作为Count()参数，计算容器中的奇数个数

            var indexElement = groupA.ElementAt(8);//根据下标取元素，下标8即第9个元素：10

            var lastElement = groupA.Last();//取最后一个元素

            var IsEqual = groupA.SequenceEqual(new[] { 1, 2, 3, 4, 5, 5, 6, 6, 10 });//判断两个容器是否相同

            var singleElement = (new[] { 99 }).Single();//判断容器中是否只有一个元素，若是则反回这个元素，否则引发异常
            var singleElement2 = (new[] { 99 }).SingleOrDefault();//若只有一个元素，若是则反回这个元素，
                                                                  //如果该序列为空，则返回默认值,可空类型的默认值是null,整型等类型默认值是0
                                                                  //若果该序列有多个元素则引发异常

            Array.ForEach(groupA.Reverse().ToArray(), n => Console.Write(n + " "));//元素倒序

            var anyElement = groupA.Any();//判断容器是否为空，不为空则true,效果等价于groupA.Count()>0;

            var IsAnyEven = new int[] { 1, 3, 4 }.Any(n => (n % 2) == 0);//是否有一部分元素满足是偶数,返回值是true

            var IsAllEven = new int[] { 2, 4 }.All(n => (n % 2) == 0);//若全是偶数则为true

            var whereElement = groupA.Where(n => n > 9);

            Console.WriteLine("\r\n" + "--------------------------------");

            //将groupA中的数组分页显示，每页显示2条数据
            #region linq分页
            var dateList = new[] { "shan1", "shan2", "shan3", "shan4", "shan5", "shan6", "shan7" };
            int pageSize = 2;//每页两个数据
            double dataTotal = Convert.ToDouble(dateList.Length);//共计7条数据,注意使用double类型，为了dataTotal / pageSize结果也是double类型
            int pageTatol = Convert.ToInt32(Math.Ceiling(dataTotal / pageSize));//共计4页

            int pageIndex = 3;//选取第3页的数据

            //Skip(n)为跳过n个元素，Take（n)获取n个数据（不足n条也不会报错）
            var pageContent = dateList.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            Array.ForEach(pageContent.ToArray(), n => Console.WriteLine(n));//输出：shan5,shan6
            #endregion




            Console.ReadKey();
        }
    }
}
