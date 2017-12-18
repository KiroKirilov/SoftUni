using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advertisement_message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = { "Excellent product.",              //6 elements
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product." };

            string[] events = { "Now I feel good.",                 //6 elements
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!" };

            string[] authors = { "Diana",                           //8 elements
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva" };

            string[] cities = { "Burgas",                           // 5 elements
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse" };


            var amountOfAds = int.Parse(Console.ReadLine());
            Random rngPhrase = new Random();
            Random rngEvent = new Random();
            Random rngAuthor = new Random();
            Random rngCity = new Random();

            for (int i = 0; i < amountOfAds; i++)                               //{phrase} {event} {author} – {city}
            {
                Console.WriteLine("{0} {1} {2} – {3}", phrases[rngPhrase.Next(0, 6)], events[rngEvent.Next(0, 6)], authors[rngAuthor.Next(0, 8)], cities[rngCity.Next(0, 5)]);
            }
        }
    }
}