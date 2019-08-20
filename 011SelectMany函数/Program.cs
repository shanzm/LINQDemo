using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011SelectMany函数
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 使用多个from引入多个数据源
            //var groupA = new[] { 3, 4, 5, 6 };
            //var groupB = new[] { 6, 7, 8, 9 };
            //var query = from a in groupA
            //            from b in groupB
            //            where a == b
            //            select new { c=a };

            //foreach (var item in query)
            //{
            //    //Console.WriteLine($"a={item.a},b={item.b},sum={item.sum}");
            //    Console.WriteLine(item);//注意匿名对象是可以直接打印的
            //}
            //Console.ReadKey();
            #endregion

            #region 使用Linq函数式
            ////需要使用容器中元素下标的时候，使用SelectMany（）
            //var groupA = new[] { 3, 4, 5, 6 };
            //var groupB = new[] { 6, 7, 8, 9 };
            ////两个参数分别是groupA中的元素和元素的下标，为什么是groupA中的呢？因为你是使用groupA.SelectMany()
            //var query = groupA.SelectMany((a, indexA) => from b in groupB where a == b select new { index = indexA, c = a });

            //foreach (var item in query)
            //{
            //    //Console.WriteLine($"a={item.a},b={item.b},sum={item.sum}");
            //    Console.WriteLine(item);//注意匿名对象是可以直接打印的
            //}
            //Console.ReadKey();
            #endregion

            #region 什么时候使用select（），什么时候使用SelectMang()

            ///如果你是仅仅查询表中的某个列（属性）的，并对其使用聚合函数（sum，count,avg）,
            ///那么select适合你 StudentTable.select(x => x.age >= 20).count()——查询学生表中年龄大于20的人数

            /// 如果你查询表中的某个集合，但是你又想对集合里的对象进行聚合，
            /// 那么select many适合你 SchoolTable.SelectMany(x => x.StudentCollection).Where(y => y.age >= 20).count()——查询学校表里中的学生表中年龄大于20的人数
            

            #endregion
        }
    }
}
