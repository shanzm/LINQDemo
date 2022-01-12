using System;
using System.Collections.Generic;

namespace TempTest
{
    /// <summary>
    /// Linq中查询操作符是对IEnumberable<T>的扩展
    /// 比如说Where函数是的参数是一个返回值是bool类型的委托对象
    /// 这里模拟，对User对象添加一个扩展方法，实现筛选
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<User> listUser = new List<User>()
                {
                   new User() { Id = 1, Name = "张三", Age = 16, Gender = "男" },
                   new User() { Id = 2, Name = "李四", Age = 19, Gender = "女" },
                   new User() { Id = 3, Name = "王五", Age = 20, Gender = "男" }
                };
            //Predicate<User> isAdult = p => p.Age > 18;
            //listUser.MyWhere(isAdult);
            var result = listUser.MyWhere(n => n.Age > 18);
            foreach (var item in result)
            {
                Console.WriteLine(item.Name + ":" + item.Age + ";" + item.Gender);
            }

            Console.ReadKey();
        }



    }


    /// <summary>
    /// List<User>扩展方法辅助类
    /// </summary>
    public static class extendListUser
    {
        /// <summary>
        /// List<User>类的扩展方法，对User对象集合过滤
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<User> MyWhere(this IEnumerable<User> users, Predicate<User> predicate)
        {
            foreach (User item in users)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }


}
