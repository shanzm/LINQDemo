using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016Aggregate累加器函数
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 累计求积
            //var group = new [] { 1, 2, 3, 4, 5 };
            //var result = group.Aggregate((total, next) => total * next);
            /////1*2=2;2*3=6;6*4=24;24*5=120
            //Console.WriteLine(result);
            //Console.ReadKey();
            #endregion

            #region 实现集合求和
            var group = new[] { 1, 1, 3, 3, 5, 5 };
            var sum = group.Aggregate((total, next) => total + next);
            Console.WriteLine(sum);
            Console.ReadKey();
            #endregion

            //求5的阶乘
            Console.WriteLine(GetFactorial3(5));
            Console.ReadKey();

        }
        #region 实现阶乘1
        public static int GetFactorial(int num)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= num; i++)
            {
                list.Add(i);
            }

            int factorial = list.Aggregate((total, next) => total * next);
            return factorial;
        }
        #endregion

        #region 实现阶乘2
        public static int GetFactorial2(int num)
        {
            int result = 1;
            for (int i = 1; i <= num; i++)
            {
                result = result * i;
            }
            return result;
        }
        #endregion

        #region 实现阶乘3-递归
        public static int GetFactorial3(int num)
        {
            if (num<1)
            {
                return 0;
            }
            if (num==1)
            {
                return 1;
            }
            return num * GetFactorial3(num - 1);
        }
        #endregion
    }
}
