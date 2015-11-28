using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<username>.*)\@(?<domain>(.*)\.(.*))";
            string input = "roman1blum@gmail.com";

            Regex regex = new Regex(pattern);
            var match = regex.Match(input);

            if (match.Success)
            {
                string username = match.Groups["username"].Value;
                string domain = match.Groups["domain"].Value;

                Console.WriteLine("Username: " + username);
                Console.WriteLine("Domain: " + domain);
            }

            Console.ReadKey();
        }
    }
}
