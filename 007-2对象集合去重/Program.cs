using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_2对象集合去重
{
    class Program
    {
        //参考：https://blog.csdn.net/laizhixue/article/details/89228355


        static void Main(string[] args)
        {
            List<Student> students = GetListStu();

            //直接使用Distinct函数是无法对对象集合去重的
            //IEnumerable<Student> result = students.Distinct();
            //result.ToList().ForEach(n => Console.WriteLine(n.ID + n.Name + n.Age + n.Gender));


            //法1
            //依旧是使用Distinct函数，其有两重重载，第二重就是使用自定义比较器
            //我们需要定义一个比较器，定义两个对象什么是相等
            //IEnumerable<Student> students1 = students.Distinct(new DistanctStudentComparer());
            //students1.ToList().ForEach(n => Console.WriteLine(n.ID + n.Name + n.Age + n.Gender));


            //法2
            //https://docs.microsoft.com/zh-cn/dotnet/api/system.linq.enumerable.distinct?view=net-5.0
            //Student实现IEquatable<T>接口,实现接口中的Equals和GetHashCode 函数
            //不好，项目中的对象一般轻易不要修改，为了实现比较两个对象，去对某个对象类实现该接口比较麻烦


            //法3（推荐）
            //使用group by聚合
            //List<Student> students2 = students.GroupBy(n => new { n.ID, n.Name, n.Age, n.Gender }).Select(n => n.First()).ToList();
            //students2.ForEach(n => Console.WriteLine(n.ID + n.Name + n.Age + n.Gender));


            //法4
            //使用扩展方法，对IEnumerable<TSource>扩展
            List<Student> students3 = students.DistinctBy(n => new { n.ID, n.Gender }).ToList();
            students3.ForEach(n => Console.WriteLine(n.ID + n.Name + n.Age + n.Gender));

            

            Console.ReadKey();
        }


        static List<Student> GetListStu()
        {
            List<Student> students = new List<Student>()
            {
                new Student() { ID = 1, Name = "张三", Age = 18, Gender = "男" },
                new Student() { ID = 1, Name = "张三", Age = 18, Gender = "男" },
                new Student() { ID = 3, Name = "李四", Age = 18, Gender = "男" },
                new Student() { ID = 3, Name = "李四1", Age = 18, Gender = "男" },
                new Student() { ID = 3, Name = "李四", Age = 18, Gender = "女" },
                new Student() { Name = "张三", Age = 18, Gender = "男" }
            };
            return students;
        }



    }

    //自定义比较器
    //怎么定义两个Student对象相等呢？这里我们定义只要ID,Name,Age三个属性相等的则认为两个对象相等
    //下面代码中就是排除比较Student对象的Gender属性
    public class DistanctStudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return x.ID == y.ID && x.Name == y.Name && x.Age == y.Age /*&& x.Gender == y.Gender*/;
        }

        public int GetHashCode(Student student)
        {
            return student.ID.GetHashCode() ^ student.Name.GetHashCode() ^ student.Age.GetHashCode() /*^ student.Gender.GetHashCode()*/;
        }
    }

    //对IEnumerable<T>扩展一个DistinctBy方法
    public static class DistinctHelper
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var identifiedKeys = new HashSet<TKey>();
            return source.Where(element => identifiedKeys.Add(keySelector(element)));
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}