using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007Distinct函数_移除重复
{
    class Program
    {
        static void Main(string[] args)
        {
            //RemoveDuplicates();
            //GetDuplicates();
            //CountDuplicates();
            int[] intAry = { 1, 2, 3, 4, 5, 6, 6, 5 };
            int[] result = RemoveDuplicates(intAry);
            Array.ForEach(result, n => Console.WriteLine(n));
            Console.ReadKey();
        }

        //除去重复元素
        private static void RemoveDuplicates()
        {
            List<string> strList1 = new List<string>() { "a", "b", "c", "a" };

            //var listDistinct = (from o in strList1 select o).Distinct();//其实集合List也是有Distinct()方法的

            var listDistinct = strList1.Distinct();

            Array.ForEach(listDistinct.ToArray(), o => Console.WriteLine($"移除集合中的重复相:{o}"));
            Console.ReadKey();
        }

        //获取重复的元素
        private static void GetDuplicates()
        {
            List<string> strList1 = new List<string>() { "a", "b", "c", "a", "b" };
            List<string> duplicatesList = strList1.GroupBy(e => e).Where(g => g.Count() > 1).Select(s => s.Key).ToList();
            Array.ForEach(duplicatesList.ToArray(), o => Console.WriteLine(o));
            Console.ReadKey();
        }

        //获取重复元素的数量
        private static void CountDuplicates()
        {
            List<string> strList1 = new List<string>() { "a", "b", "c", "a", "b" };
            var query = strList1.GroupBy(e => e).Where(g => g.Count() > 1).Select(s => new { Key = s.Key, Count = s.Count() }).ToList();
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        //自己实现去除重复元素的算法
        private static int[] RemoveDuplicates(int[] a)
        {
            int len = 0;
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++, len++)
            {
                b[len] = a[i];
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] == a[j])
                    {
                        len--;
                        break;
                    }
                }
            }
            int[] new_a = new int[len];
            for (int k = 0; k < len; k++)
            {
                new_a[k] = b[k];
            }
            return new_a;
        }
    }
}
