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
            #region 测试数据源
            var students = new[]
            {
                   new { Name = "张三", Age = 10, Group = "A" },
                   new { Name = "张三", Age = 20, Group = "A" },
                   new { Name = "张三", Age = 20, Group = "B" },
                   new { Name = "李四", Age = 10, Group = "B" },
                   new { Name = "李四", Age = 10, Group = "B" },
                   new { Name = "王五", Age = 10, Group = "C" },
                   new { Name = "赵六", Age = 10, Group = "C" },
                   new { Name = "周七", Age = 10, Group = "C" }
             };
            #endregion



            #region GroupBy()函数

            //方法语法
            var groupValues = students.GroupBy(n => n.Group);
            //查询表达式
            //var groupValues = from n in students
            //                   group n by n.@Group;//group是关键字，做转义
            //注意groupValues是：
            //{
            //    { Key = "A", { Name = "张三", Age = 10, Group = "A" },{ Name = "张三", Age = 20, Group = "A" } } ,
            //    { Key = "B", { Name = "张三", Age = 20, Group = "B" },{ Name = "李四", Age = 10, Group = "B" },{ Name = "李四", Age = 10, Group = "B" } },
            //    { Key = "C", { Name = "王五", Age = 10, Group = "C" },{ Name = "赵六", Age = 10, Group = "C" },{ Name = "周七", Age = 10, Group = "C" }},
            //}
            //foreach (var g in groupValues)
            //{
            //    //记住：分组后的数据是组，你可以对组中数组在做遍历
            //    Console.WriteLine("=============Group:{0}=============", g.Key);
            //    foreach (var item in g)
            //    {
            //        Console.WriteLine("name:{0}, value:{1}", item.Name, item.Age);
            //    }
            //}


            //根据多属性分组（相当于按照指定的属性去重）
            //这里的Count和该组的数量(相当于重复的记录数量)
            var groupValuesCount =
                students
                .GroupBy(n => new { n.Name, n.Age, n.Group })
                //Key中所有的分组依据列
                .Select(group => new { Name = group.Key.Name, Age = group.Key.Age, Group = group.Key.Group, Count = group.Count() }).ToList();

            groupValuesCount.ForEach(n => Console.WriteLine($"姓名{n.Name} ,年龄 {n.Age} ,组别 {n.Group} ,按照姓名年龄组别聚合_重复数{ n.Count}"));


            //分组聚合
            //安装Group分组，求该组的年龄和
            var groupValuesSum =
                students
                .GroupBy(n => new { n.Group })
                .Select(group => new { Group = group.Key.Group, AgeSum = group.Sum(n => n.Age), Count = group.Count(), AgeAvg = group.Average(n => n.Age) }).ToList();
            groupValuesSum.ForEach(n => Console.WriteLine($"组别：{n.Group},年龄和{n.AgeSum},人数{n.Count},平均年龄{n.AgeAvg}"));



            Console.ReadKey();
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
            //var query = from p in students
            //            group p by p.@Group into g//使用into...语句获取分组的组的数据
            //            select new { groupName = g.Key, groupCount = g.Count(), groupAvg = g.Average(p => p.Age) };
            //Array.ForEach(query.ToArray(), n => Console.WriteLine($"组名{n.groupName},每组的人数{n.groupCount},每组的平均值{n.groupAvg}"));
            //Console.ReadKey();

            #endregion

        }

    }
}
