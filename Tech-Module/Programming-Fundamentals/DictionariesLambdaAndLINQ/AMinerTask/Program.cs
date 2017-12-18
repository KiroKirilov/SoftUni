using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miner_task
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            string resource = "";
            int quantity;
            while (true)
            {
                resource = Console.ReadLine();
                if (resource == "stop")
                {
                    break;
                }

                quantity = int.Parse(Console.ReadLine());
                if (dict.ContainsKey(resource))
                {
                    dict[resource] += quantity;
                }
                else
                {
                    dict[resource] = quantity;
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}