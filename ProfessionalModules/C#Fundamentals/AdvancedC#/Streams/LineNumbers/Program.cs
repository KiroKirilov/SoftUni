using System;
using System.IO;

namespace PrintOddLines
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var reader = new StreamReader("text.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    string line;
                    var counter = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {counter}: {line}");
                        counter++;
                    }
                }
            }
        }
    }
}