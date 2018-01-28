using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace some_shit
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var text = new StringBuilder();
            var versions = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var query = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (query[0] == "1")
                {
                    versions.Push(text.ToString());
                    text.Append(query[1]);

                }

                if (query[0] == "2")
                {
                    var count = int.Parse(query[1]);
                    versions.Push(text.ToString());

                    if (count > text.Length)
                    {
                        text.Clear();
                        continue;
                    }

                    text.Length -= count;
                }

                if (query[0] == "3")
                {
                    var index = int.Parse(query[1]);

                    if (index <= text.Length && index > 0)
                    {
                        Console.WriteLine(text[index - 1]);
                    }
                }

                if (query[0] == "4")
                {
                    text.Clear();
                    text.Append(versions.Pop());
                }
            }
        }
    }
}
