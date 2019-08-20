using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016Aggregate累加器函数2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 在字符串中反转单词的排序
            string str = "I am Shanzm";
            string[] strArray = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string result = strArray.Aggregate((workingSentence, next) => next + " " + workingSentence);
            //am+" "+I;Shanzm+" " +"am I"
            Console.WriteLine(result);
            Console.ReadKey();
            #endregion

            #region 使用 Aggregate 应用累加器函数和结果选择器
            //下例使用linq的Aggregate方法找出数组中大于"banana", 长度最长的字符串，并把它转换大写。
            string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };

            //字符串"banana"作为种子值，用作累加器初始值。
            string longestName =
              fruits.Aggregate("banana",
                 (longest, next) =>
                  next.Length > longest.Length ? next : longest,
                 fruit => fruit.ToUpper());
            //banana>apple故longest=banana;banana>mango故longest=banana……
            Console.WriteLine("The fruit with the longest name is {0}.", longestName);
            Console.ReadKey();
            #endregion

        }
    }
}
