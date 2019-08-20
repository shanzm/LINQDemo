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
            #region SelectBy()函数
            // var nameValuesGroup = new[]
            //{
            //     new { name = "Allen", value = 65, group = "A" },
            //     new { name = "Abbey", value = 120, group = "A" },
            //     new { name = "slong", value = 330, group = "B" },
            //     new { name = "George", value = 213, group = "C" },
            //     new { name = "Meller", value = 329, group = "C" },
            //     new { name = "Mary", value = 192, group = "B" },
            //     new { name = "Sue", value = 200, group = "C" }
            // };
            // //var groupValues = from o in nameValuesGroup
            // //                  group o by o.@group;//group是关键字，做转义
            // var groupValues = nameValuesGroup.GroupBy(c => c.group);
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
            //ToLookup函数的用法和GroupBy()一样
            //结果好像也是一样，但是我们知道Linq是延迟执行，就像为了使Linq立即查询，我们会在结果使用.ToArray(),ToList()
            //ToLookup() 的结果是立即执行的，而GroupBy（） 的结果仍然是延迟执行
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
            
            var groupValues = nameValuesGroup.ToLookup(c => c.group);
            foreach (var g in groupValues)
            {
                //记住：分组后的数据是组，你可以对组中数组在做遍历
                Console.WriteLine("===Group:{0}===", g.Key);
                foreach (var item in g)
                    Console.WriteLine("name:{0}, value:{1}", item.name, item.value);
            }
            Console.ReadKey();
            #endregion

        }

    }
}
