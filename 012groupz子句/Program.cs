using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013groupz子句
{
    class Program
    {
        static void Main(string[] args)
        {
            #region GroupBy()函数
            // var nameValuesGroup = new[]
            //{
            //       new { name = "Allen", value = 65, group = "A" },
            //       new { name = "Abbey", value = 120, group = "A" },
            //       new { name = "slong", value = 330, group = "B" },
            //       new { name = "George", value = 213, group = "C" },
            //       new { name = "Meller", value = 329, group = "C" },
            //       new { name = "Mary", value = 192, group = "B" },
            //       new { name = "Sue", value = 200, group = "C" }
            //   };

            // var groupValues = nameValuesGroup.GroupBy(c => c.group);
            // //等价于：
            // //var groupValues = from o in nameValuesGroup
            // //                  group o by o.@group ;//group是关键字，做转义
            ////注意groupValues是：
            ////{
            ////    { Key="A", {name="Allen", value=65, group="A"},{name="Abbey",value=120, group="A"}} ,
            ////    { Key="B", {name="slong", value=330, group="B"},{name="Mary",value=192, group="B" }},
            ////    { Key="C", {name="George",value=213, group="C"}{name="Meller",value =329,group="C"},{name="Sue",value=200, group="C"}},
            ////}
            // foreach (var g in groupValues)
            // {
            //     //记住：分组后的数据是组，你可以对组中数组在做遍历
            //     Console.WriteLine("===Group:{0}===", g.Key);
            //     foreach (var item in g)
            //         Console.WriteLine("name:{0}, value:{1}", item.name, item.value);
            // }
            // Console.ReadKey();
            #endregion

            #region ToLookup()函数
            ////ToLookup函数的用法和GroupBy()一样
            ////结果好像也是一样，但是我们知道Linq是延迟执行，就像为了使Linq立即查询，我们会在结果使用.ToArray(),ToList()
            ////ToLookup() 的结果是立即执行的，而GroupBy（） 的结果仍然是延迟执行
            //var nameValuesGroup = new[]
            // {
            //      new { name = "Allen", value = 65, group = "A" },
            //      new { name = "Abbey", value = 120, group = "A" },
            //      new { name = "slong", value = 330, group = "B" },
            //      new { name = "George", value = 213, group = "C" },
            //      new { name = "Meller", value = 329, group = "C" },
            //      new { name = "Mary", value = 192, group = "B" },
            //      new { name = "Sue", value = 200, group = "C" }
            //  };

            //var groupValues = nameValuesGroup.ToLookup(c => c.group);

            //foreach (var g in groupValues)
            //{
            //    //记住：分组后的数据是组，你可以对组中数组在做遍历
            //    Console.WriteLine("===Group:{0}===", g.Key);//注意这个分组键Key
            //    foreach (var item in g)
            //        Console.WriteLine("name:{0}, value:{1}", item.name, item.value);
            //}
            //Console.ReadKey();
            #endregion

            #region group ...by..
            var nameValuesGroup = new[]
            {
                   new { name = "Allen", value = 65, group = "A" },
                   new { name = "Abbey", value = 120, group = "A" },
                   new { name = "slong", value = 330, group = "B" },
                   new { name = "George", value = 213, group = "C" },
                   new { name = "Meller", value = 329, group = "C" },
                   new { name = "Mary", value = 192, group = "B" },
                   new { name = "Sue", value = 200, group = "C" }
              };
            var query = from p in nameValuesGroup
                        group p by p.@group into g//使用into...语句获取分组的组的数据
                        select new { groupName = g.Key, groupCount = g.Count(), groupAvg = g.Average(p=>p.value) };
            Array.ForEach(query.ToArray(), n => Console.WriteLine($"组名{n.groupName},每组的人数{n.groupCount},每组的平均值{n.groupAvg}"));
            Console.ReadKey();

            #endregion

        }

    }
}
