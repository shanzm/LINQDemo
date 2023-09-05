using System.Collections.Generic;
using System.Linq;

namespace _007_3对象集合去重
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region 测试数据

            List<User> users1 = new List<User>
            {
                new User() { Id = 1, Age = 1, Name = "Name01" },
                new User() { Id = 2, Age = 2, Name = "Name02" },
                new User() { Id = 3, Age = 3, Name = "Name03" },
                new User() { Id = 4, Age = 4, Name = "Name04" }
            };

            List<User> users2 = new List<User>
            {
                new User() { Id = 4, Age = 44, Name = "Name044" },
                new User() { Id = 5, Age = 55, Name = "Name01" },
                new User() { Id = 6, Age = 66, Name = "Name06" },
                new User() { Id = 7, Age = 77, Name = "Name07" },
                new User() { Id = 8, Age = 88, Name = "Name08" }
            };

            #endregion

            //把两个list合并在一起
            List<User> result1 = new List<User>();
            result1.AddRange(users1);
            result1.AddRange(users2);

            //注意我们在User中重写了Equals和GetHashCode方法
            //所以判断两个User是否一样，已User.Id作为判断依据

            //去重：在result1中去重
            List<User> result2 = result1.Distinct().ToList();

            //差集：users1在users2之中的差集
            List<User> result3 = users1.Except(users2).ToList();

            //并集：users1与users2 合起来不重复的元素
            List<User> result4 = users1.Union(users2).ToList();

            //交集：users1与users2 相同的元素
            List<User> result5 = users1.Intersect(users2).ToList();
        }

        /// <summary>
        /// 定义User实体类
        /// </summary>
        public class User
        {
            public long Id { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }

            /// <summary>
            /// 重写Equals,根据User.Id为依据判断User对象是否为相同
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                User u = (User)obj;
                if (Id != 0 && u.Id == Id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// 重写HashCode
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return Id.GetHashCode();
            }

            public override string ToString()
            {
                return string.Format("id=" + Id);
            }
        }
    }
}
