using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fix_emails
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();
            string name = "";
            string email = "";
            while (true)
            {
                name = Console.ReadLine();
                if (name == "stop")
                {
                    break;
                }
                email = Console.ReadLine();

                var lastTwo = email.Substring(email.Length - 2).ToLower();

                if (lastTwo == "us" || lastTwo == "uk") continue;
                else
                {
                    dict[name] = email;
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}