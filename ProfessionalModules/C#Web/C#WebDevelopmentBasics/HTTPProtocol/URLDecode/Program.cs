using System;
using System.IO;
using System.Net;

namespace URLDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            string encodedUrl = Console.ReadLine();
            string decodedUrl=WebUtility.UrlDecode(encodedUrl);
            Console.WriteLine(decodedUrl);
        }
    }
}
