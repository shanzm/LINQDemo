using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001使用Linq查询非泛型集合
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList persons = new ArrayList()
            {
                new Person {Name="shanzm",Age=13 },
                new Person {Name="shanzm2",Age=15 }
            };

            //ArrayList persons：定义的是非泛型的所以Linq语句是无法使用的： from p in persons where p.Age > 14 select p
            //List<Person>就是泛型，就可以使用Linq
            var myArrayList = persons.OfType<Person>();

            //var result = from p in myArrayList where p.Age > 14 select p;//使用Linq语句
            var result = myArrayList.Where(p => p.Age > 14);//使用Linq函数

            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }
    }

    internal class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
