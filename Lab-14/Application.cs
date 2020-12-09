using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Lab_14.SportsEquipment;

namespace Lab_14
{
    public class Application
    {
        public static Random rand;
        static void Main(string[] args)
        {
            void ColoredOutput(object obj, ConsoleColor fgc, ConsoleColor bgc)
            {
                Console.BackgroundColor = bgc;
                Console.ForegroundColor = fgc;
                Console.WriteLine(obj);
                Console.ResetColor();
            }

            rand = new Random(DateTime.Now.Millisecond);
            Gym gym = new Gym(250.0);
            while (gym.HasMoney)
            {
                gym.AddItem(new Bar());
                gym.AddItem(new Bench());
            }
            GymController gc = new GymController(gym);

            ColoredOutput("\nBinary serialization\n", ConsoleColor.Black, ConsoleColor.White);
            Serializator.SerializeToBinary(gc);
            ColoredOutput("Object for write to file -->", ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine(gc);
            Console.ReadKey();
            ColoredOutput("Object was readed from file <--", ConsoleColor.Black, ConsoleColor.White);
            gc = (GymController)Serializator.DeserializeFromBinary(gc.GetType().FullName + ".bin");
            Console.WriteLine(gc);

            Bar bar = new Bar();

            ColoredOutput("\nSOAP serialization\n", ConsoleColor.Black, ConsoleColor.White);
            Serializator.SerializeToSOAP(bar);
            ColoredOutput("Object for write to file -->", ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine(bar);
            Console.ReadKey();
            ColoredOutput("Object was readed from file <--", ConsoleColor.Black, ConsoleColor.White);
            bar = (Bar)Serializator.DeserializeFromSOAP(bar.GetType().FullName + ".soap");
            Console.WriteLine(bar);

            Equipment[] eqp = new Equipment[] { new Bar(), new Bench(), new Mat() };

            ColoredOutput("\nJSON serialization\n", ConsoleColor.Black, ConsoleColor.White);
            Serializator.SerializeToJSON(eqp);
            ColoredOutput("Object for write to file -->", ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine(string.Join("\n", eqp.AsEnumerable()));
            Console.ReadKey();
            ColoredOutput("Object was readed from file <--", ConsoleColor.Black, ConsoleColor.White);
            eqp = (Equipment[])Serializator.DeserializeFromJSON(eqp.GetType().FullName + ".json");
            Console.WriteLine(string.Join("\n", eqp.AsEnumerable()));

            ColoredOutput("\nXML serialization\n", ConsoleColor.Black, ConsoleColor.White);
            Serializator.SerializeToXML(bar);
            ColoredOutput("Object for write to file -->", ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine(bar);
            Console.ReadKey();
            ColoredOutput("Object was readed from file <--", ConsoleColor.Black, ConsoleColor.White);
            bar = (Bar)Serializator.DeserializeFromXML(bar.GetType().FullName + ".xml");
            Console.WriteLine(bar);
            Console.WriteLine();

            Console.WriteLine("XPath");
            XmlDocument xmlDoc = new XmlDocument(); xmlDoc.Load("Lab_14.SportsEquipment.Bar.xml");
            foreach (XmlAttribute attr in xmlDoc.SelectNodes("//*/@*"))
                Console.WriteLine($"\t{attr.Value}");
            Console.WriteLine();
            foreach (XmlElement el in xmlDoc.SelectNodes("//*/*"))
                Console.WriteLine($"\t{el.LocalName}");
            Console.WriteLine();


            Console.WriteLine("LINQ to XML");
            XDocument xdoc = new XDocument(new XElement("PROJECTS",
                new XElement("PROJECT",
                    new XAttribute("name", "Snake"),
                    new XElement("company", "KHCorp"),
                    new XElement("price", "0$"),
                    new XElement("licence", "MIT License")),
                new XElement("PROJECT",
                    new XAttribute("name", "Tetrus"),
                    new XElement("company", "KSPCorp"),
                    new XElement("licence", "MIT License")),
                new XElement("PROJECT",
                    new XAttribute("name", "Sking Civs"),
                    new XElement("company", "KHCorp"),
                    new XElement("price", "33000$"))));
            xdoc.Save("PROJECTS.xml");
            xmlDoc.Load("PROJECTS.xml");
            Console.WriteLine("Projects with 'company' == 'KHCorp'");
            foreach (var xnode in from node in xdoc.Element("PROJECTS").Elements("PROJECT")
                                 where node.Element("company").Value == "KHCorp"
                                 select node)
                Console.WriteLine("\t" + string.Join("\n\t", (from xel in xnode.Elements() select $"{xel.Name} = {xel.Value}").Append("")) );
            Console.WriteLine("Projects with 'price' and 'license':");
            foreach (var xnode in from node in xdoc.Element("PROJECTS").Elements("PROJECT")
                                  where node.Element("price") != null && node.Element("licence") != null
                                  select node.Attribute("name").Value)
                Console.WriteLine("\t" + xnode);

            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static void ToLog(this string str) => Console.WriteLine(str);
    }
}
