using System;
using System.IO;

namespace PrintOddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader=new StreamReader("text.txt"))
            {
                string line;
                var counter = 1;
                while ((line=reader.ReadLine())!=null)
                {
                    if (counter % 2 == 0)
                        Console.WriteLine(line);
                    counter++;
                }
            }
        }
    }
}
