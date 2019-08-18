using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009Contains
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strList = new List<string>() { "shanzm", "shan zm" };
            var result = from o in strList where o.Contains(" ") select o;
            Array.ForEach(result.ToArray(), o => Console.WriteLine(o));
            Console.ReadKey();
        }
    }
}
