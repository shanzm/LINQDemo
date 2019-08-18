using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _010_使用Select将单词的首字母改为大写
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 使用Linq表达式
            //string str = "i am shanzm";
            //string[] strArray = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //var query = from o in strArray
            //            select o.Replace(o[0], Convert.ToChar(o[0].ToString().ToUpper()));
            //Array.ForEach(query.ToArray(), o => Console.Write(o + " "));
            //Console.ReadKey();
            #endregion


            #region 使用Linq函数式
            string str = "i am  shanzm";
            string[] strArray = Regex.Split(str, @"\s+").ToArray();
            var query = strArray.Select(o => o.Replace(o[0], Convert.ToChar(o[0].ToString().ToUpper())));

            //Array.ForEach(query.ToArray(), o => Console.Write(o + " "));
            //我们可以把打印数组的功能使用扩展方法的形式，添加到IEnumerable<T>类中
            query.WriteLineAll();
            Console.ReadKey();
            #endregion

        }

    }
    #region 关于使用this关键字实现扩展方法
    public static class Extender
    {
        public static void WriteLineAll<T>(this IEnumerable<T> array)
        {
            Array.ForEach(array.ToArray(), o => Console.Write(o + " "));
        }
    }
    #endregion
}
