using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            UseStringBuilder();
            Console.ReadKey();

            Console.Clear();

            UseSubstringAndRegex();
            Console.ReadKey();

            Console.Clear();

            UseSplitAndJoin();
            Console.ReadKey();

            Console.Clear();

            UseStringReader();
            Console.ReadKey();

            Console.Clear();

            UseStringWriter();
            Console.ReadKey();
        }

        private static void UseStringWriter()
        {
            /* 
                StringWriter implements all its Write... methods by forwarding on to an 
                instance of StringBuilder that it stores in a field. This is not merely 
                an internal detail, because StringWriter has a public method 
                GetStringBuilder that returns the internal string builder, and also a 
                constructor that allows you to pass in an existing StringBuilder.

                So StringWriter is an adaptor that allows StringBuilder to be used as a 
                target by code that expects to work with a TextWriter. In terms of basic 
                behaviour there is clearly nothing to choose between them... unless you 
                can measure the overhead of forwarding the calls, in which case 
                StringWriter is slightly slower, but that seems very unlikely to be 
                significant.
            */
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                writer.WriteLine("This is a line.");
                writer.WriteLine("Another line.");
            }
            Console.WriteLine(sb.ToString());
        }

        private static void UseStringReader()
        {
            string input = "Lorem ipsum dolor sit amet.\nBla bla bla";

            // Creates new StringReader instance from System.IO
            using (StringReader reader = new StringReader(input))
            {
                // Loop over the lines in the string.
                int count = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                    Console.WriteLine("Line {0}: {1}", count, line);
                }
            }
        }

        private static void UseSplitAndJoin()
        {
            var strings = new StringBuilder();

            strings.AppendLine("FirstName,LastName,Company");
            strings.AppendLine("Essie,Vaill,Litronic Industries");
            strings.AppendLine("Cruz,Roudabush,Meridian Products");
            strings.AppendLine("Billie,Tinnes,D & M Plywood Inc");
            strings.AppendLine("Zackary,Mockus,Metropolitan Elevator Co");
            strings.AppendLine("Rosemarie,Fifield,Technology Services");

            var csv = strings.ToString();

            // split into lines
            var lines = csv.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            
            // create a pipe "|" delimited string instead
            foreach(string line in lines)
            {
                // split line into fields
                var fields = line.Split(new[] { ',' }, StringSplitOptions.None);

                string newLine = string.Join("###", fields);
                Console.WriteLine(newLine);
            }
        }

        private static void UseSubstringAndRegex()
        {
            var x = "The quick brown fox jumped over the lazy dog";

            // one
            Console.WriteLine(x.Substring(4, 5));

            // two
            var stringSplit = x.Split(' ');
            Console.WriteLine(stringSplit[1]);

            // three
            var regexSplit = System.Text.RegularExpressions.Regex.Split(x, " ");
            Console.WriteLine(regexSplit[1]);

            // four
            var regexFind = System.Text.RegularExpressions.Regex.Match(x, "(The )(.+)( brown)");
            Console.WriteLine(regexFind.Groups[2].Value);
        }

        private static void UseStringBuilder()
        {
            // create a stringbuilder instance
            var sb = new StringBuilder();

            // append lines
            sb.AppendLine("This is the original first line");
            sb.AppendLine("This is another line");

            // append formatted values
            for (int i = 0; i < 10; i++)
            {
                sb.AppendFormat(
                    "Inserting line with loop index {0,5} on {1,9:d} {2}", i, DateTime.Now, Environment.NewLine);
            }

            // replace values
            sb.Replace("index", "counter");

            // insert 
            var newLine = string.Format("This is a new first line {0}", Environment.NewLine);
            sb.Insert(0, newLine);

            // remove
            sb.Remove(0, newLine.Length);

            // convert to a string
            var s1 = sb.ToString();
            Console.WriteLine(s1);

            // convert a subset to a string
            var s2 = sb.ToString(10, 10);
            Console.WriteLine(s2);
        }
    }
}
