using System;
using System.Collections.Generic;
using System.Linq;

namespace _23依据集合对另一个集合筛选
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //需求很简单：有一个User对象集合，这个对象有一个Id字段，我们需要根据指定的Id集合筛选User集合
            //可以理解为实现SQL中的IN筛选
            //在Linq中可以使用Where配合Any实现该筛选

            List<User> listUser = new List<User>
            {
                new User() { Id = 1, Age = 1, Name = "Name01" },
                new User() { Id = 2, Age = 2, Name = "Name02" },
                new User() { Id = 3, Age = 3, Name = "Name03" },
                new User() { Id = 4, Age = 4, Name = "Name04" }
            };

            List<int> listId = new List<int>() { 1, 4, 5 };

            //实现类似in筛选
            List<User> result1 = listUser.Where(n => listId.Any(m => n.Id == m)).ToList();
            List<User> result2 = listUser.Where(n => listId.Contains(n.Id)).ToList();
            //注意：这样是无法实现类似not in 的筛选，Any表示判读是否存在，存在在返回true
            //List<User> result2 = listUser.Where(n => listId.Any(m => n.Id != m)).ToList();//这是错误的
            //实现not in筛选
            List<User> result3 = listUser.Where(n => !listId.Any(m => n.Id == m)).ToList();
            List<User> result4 = listUser.Where(n => !listId.Contains(n.Id)).ToList();

            result1.ForEach(n => Console.WriteLine(n.Id + n.Name + n.Age));
            Console.WriteLine("------------");
            result2.ForEach(n => Console.WriteLine(n.Id + n.Name + n.Age));
            Console.WriteLine("------------");
            result3.ForEach(n => Console.WriteLine(n.Id + n.Name + n.Age));
            Console.WriteLine("------------");
            result4.ForEach(n => Console.WriteLine(n.Id + n.Name + n.Age));

            Console.ReadKey();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
