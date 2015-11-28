using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadXml();
            WriteXml();
            Console.ReadKey();
        }

        private static void ReadXml()
        {
            var text = "<Galaxy Name=\"Milky Way\">Space<SolarSystem Name=\"Sol\"><Planet Position=\"1\">Mercury</Planet><Planet Position=\"2\">Venus</Planet><Planet Position=\"3\">Earth</Planet><Planet Position=\"4\">Mars</Planet></SolarSystem></Galaxy>";
            var xml = XElement.Parse(text);
            string value;

            value = xml.Value;
            Output(value);

            var texts = xml
                .Nodes().OfType<XText>()
                .Select(x => x.Value);
            value = texts.Any() ? string.Join(string.Empty, texts) : "EMPTY";
            Output(value);

            value = xml.Attribute("Name").Value;
            Output(value);

            value = xml
                .Descendants("SolarSystem").First()
                .Attribute("Name").Value;
            Output(value);

            var planet = xml
                .Descendants("SolarSystem").First()
                .DescendantNodes().First();
            while (planet != null)
            {
                Console.WriteLine("Planet: {0}", (planet as XElement).Value);
                planet = planet.NextNode;
            }

            value = xml
                .Descendants("SolarSystem").First()
                .Elements().ToArray()[2].Value;
            Output(value);
        }

        private static void WriteXml()
        {
            XElement xml;
            XNamespace ns = "https://github.com/rmnblm";

            xml = new XElement(ns + "Galaxy", "Space");
            Output(xml.ToString());

            xml = new XElement(ns + "Galaxy", "Space",
                new XAttribute(XNamespace.Xmlns + "j", ns));
            Output(xml.ToString());

            xml = new XElement("Galaxy", "Space", new XAttribute("Name", "Milky Way"));
            Output(xml.ToString());

            xml = new XElement("Galaxy", "Space", new XAttribute("Name", "Milky Way"),
                    new XElement("SolarSystem",
                        new XAttribute("Name", "Sol"),
                        new XElement("Planet", "Mercury", new XAttribute("Position", "1")),
                        new XElement("Planet", "Venus", new XAttribute("Position", "2")),
                        new XElement("Planet", "Earth", new XAttribute("Position", "3")),
                        new XElement("Planet", "Mars", new XAttribute("Position", "4"))
                        )
                    );
            Output(xml.ToString());
        }

        static void Output(string value)
        {
            Console.Clear();
            Console.WriteLine(value);
            Console.ReadKey();
        }
    }
}
