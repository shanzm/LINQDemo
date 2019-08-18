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
            string str = "i am  shanzm";
            string[] strArray = Regex.Split(str, @"\s+").ToArray();
            var query = strArray.Select(o => o.Replace(o[0], Convert.ToChar(o[0].ToString().ToUpper())));

            Array.ForEach(query.ToArray(), o => Console.Write(o + " "));
            Console.ReadKey();


        }
    }
}
