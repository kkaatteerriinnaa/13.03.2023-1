using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp36
{
    class Program
    {
        static void Main(string[] args)
        {
            //Добавление
            XDocument xdoc = XDocument.Load("Phone.xml");
            XElement root = xdoc.Element("Phones");

            root.Add(new XElement("phone",
                        new XAttribute("name", "LG"),
                        new XElement("company", "Samsung"),
                        new XElement("age", 2023)));
            xdoc.Save("people.xml");

            Console.WriteLine(xdoc);
            //Поиск
            var search = xdoc.Element("Phones")?   
                .Elements("phone")            
                .FirstOrDefault(p => p.Attribute("name")?.Value == "LG");

            var name = search.Attribute("name").Value;
            var age = search.Element("age").Value;
            var company = search.Element("company").Value;

            Console.WriteLine($"Name: {name}  Age: {age}  Company: {company}");

            //Удаление
            var delete = root.Elements("Phones").FirstOrDefault(p => p.Attribute("name")?.Value == "LG");

            delete.Remove();
            xdoc.Save("people.xml");

            Console.WriteLine(xdoc);

            //Редоктирование
            var tom = xdoc.Element("Phones")?
                .Elements("phone")
                .FirstOrDefault(p => p.Attribute("name")?.Value == "LG");

                name = tom.Attribute("name").Value = "Tomas";
               
                age = tom.Element("age").Value = "2022";

                xdoc.Save("people.xml");

            Console.WriteLine(xdoc);
        }
    }
}
