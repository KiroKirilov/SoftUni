using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace book_library
{
    class Program
    {
        static void Main(string[] args)
        {
            var amountOfBooks = int.Parse(Console.ReadLine());      //{title} {author} {publisher} {release date} {ISBN} {price}.
            Library myLibrary = new Library() { Name = "Biblioteka", Books = new List<Book>() };
            for (int i = 0; i < amountOfBooks; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                var currentBook = new Book();
                currentBook.Title = input[0];
                currentBook.Author = input[1];
                currentBook.Publisher = input[2];
                currentBook.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                currentBook.ISBN = input[4];
                currentBook.Price = decimal.Parse(input[5]);
                myLibrary.Books.Add(currentBook);
            }
            var inputDate = Console.ReadLine();
            DateTime searchDate = DateTime.ParseExact(inputDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Dictionary<string, DateTime> booksByDate = new Dictionary<string, DateTime>();

            foreach (Book book in myLibrary.Books)
            {
                if (book.ReleaseDate.CompareTo(searchDate) > 0)
                {
                    booksByDate.Add(book.Title, book.ReleaseDate);
                }
            }
            foreach (var pair in booksByDate.OrderBy(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine("{0} -> {1:dd.MM.yyyy}", pair.Key, pair.Value);
            }
        }

        public class Library
        {
            public string Name { get; set; }
            public List<Book> Books { get; set; }
        }

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Publisher { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string ISBN { get; set; }
            public decimal Price { get; set; }
        }
    }
}