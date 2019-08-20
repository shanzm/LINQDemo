using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace _017关于XML
{
    class Program
    {
        //对XMl文件的生成&处理：https://github.com/shanzm/CSharp_XML

        //XDocument和XmlDocument都可以用来操作XML文档，
        //XDocument是.net 3.5为Linq to XML准备的轻量级Document对象，在功能上他和XmlDocument差不多，
        //但是Linq to XML只能配合XDocument使用


        static void Main(string[] args)
        {
            XDocument employeeDoc = new XDocument(//创建XML文档
            //new XDeclaration("1.0", "utf-8", null),//默认自动生成
            new XElement("Employees",//创建根元素
              new XElement("Employee", new XElement("Name", "shanzm"), new XElement("Age", "25")),
              new XElement("Employee", new XElement("Name", "shanzm2"), new XElement("Age", "25")),
              //new XElement("Employee", new XElement("Name")),//注意不加标签的内容，则是单标签
              new XComment("这是注释"))
              );

            employeeDoc.Save("EmployeeDoc.xml");
            XDocument employeeDoc2 = XDocument.Load("EmployeeDoc.xml");
            Console.WriteLine(employeeDoc2);



            //获取指定类型的节点
            XElement root = employeeDoc2.Element("Employees");
            IEnumerable<XElement> elements = root.Elements();//Nodes().OfType<XComment>();
            foreach (XElement item in elements)
            {
                XElement name = item.Element("Name");
                Console.WriteLine(name.Value);

                XElement age = item.Element("Age");
                Console.WriteLine(age.Value);
            }

            //获取根节点下面的某个节点
            XElement a = root.Element("Employee").Element("Name");
            Console.WriteLine("获取根节点下面的某个节点" + a.Value);



            Console.ReadKey();

            #region input
            // <?xml version="1.0" encoding="utf-8"?>
            //<Employees>
            //  <Employee>
            //    <Name>shanzm</Name>
            //    <Age>25</Age>
            //  </Employee>
            //  <Employee>
            //    <Name>shanzm2</Name>
            //    <Age>25</Age>
            //  </Employee>
            //  < Employee >
            //    < Name />
            //  </ Employee >
            //  < !--这是注释-- >
            //</Employees>
            #endregion
        }
    }
}
