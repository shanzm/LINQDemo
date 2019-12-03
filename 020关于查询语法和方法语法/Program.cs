using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020关于查询语法和方法语法
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 说明
            //有两种形式的语法可供我们在写LINQ查询时使用——查询语法和方法语法。
            //查询语法（query syntax）是声明形式的，看上去和SQL语句很相似。查询语法使用查询表达式形式书写。
            //方法语法（method syntax）是指使用标准查询运算符进行查询
            //标准查询运算符简单的说就是IEnumberable<T>对象的一系列的静态方法，也就是一系列的关于可序列对象(数组或集合)的API
            //一些运算符返回IEnumerable对象（或其他序列），而其他的一些运算符返回标量。返回标量的运算符立即执行，而返回替代可枚举类型对象的值会被延迟迭代。


            //微软推荐使用查询语法，因为它更易读，能更清晰地表明查询意图，因此也更不容易出错。
            //然而，有一些运算符必须使用方法语法来书写。

            //查询表达式使用的查询语法会被C#编译器转换为方法调用的形式。这两种形式在运行时性能上没有区别。

            ///我个人觉得：使用方法语法方法，即使用标准查询运算符的方式更方法，
            ///但是像.Join（）这样的方法有四个参数，写起来就很难看，所以可以使用查询语法（from...Join...)


            //在一个查询中也可以组合两种查询形式。
            //在标准查询方法中只有Where(), Select(), OrderBy(), GroupBy(), Join()用 等这些能用from语句这样的的查询写法，
            //如果要用下面的这些静态方法
            //“Max,Min,Count,Average,Sum,Any,First,FirstOrDefault,Single,SingleOrDefault,Distinct,Skip,Take 等 
            //则只能直接使用序列对象调用这些方法的写法
            #endregion
            var val = new[] { 1, 2, 3, 4, 5, 6, 5, 8, 1, 3, 4, 0 };
            var query = (from o in val
                         where o > 2
                         select o).OrderBy(n => n).Last();//结果：8
            Console.WriteLine(query);
            Console.ReadKey();

        }
    }
}
