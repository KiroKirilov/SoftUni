namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //var restriction = Console.ReadLine(); //1. Age Restriction
                //Console.WriteLine(GetBooksByAgeRestriction(db, restriction)); //1. Age Restriction

                //Console.WriteLine(GetGoldenBooks(db)); //2. Golden Books

                //Console.WriteLine(GetBooksByPrice(db)); //3. Books by Price

                //var year = int.Parse(Console.ReadLine()); // 4. Not Released In
                //Console.WriteLine(GetBooksNotRealeasedIn(db,year)); //4. Not Released In

                //var genresInput = Console.ReadLine().ToLower().Trim(); //5. Book Titles by Category
                //Console.WriteLine(GetBooksByCategory(db, genresInput)); //5. Book Titles by Category

                //var date = Console.ReadLine(); // 6. Released Before Date
                //Console.WriteLine(GetBooksReleasedBefore(db, date)); //6. Released Before Date

                //var ending = Console.ReadLine(); //7. Author Search
                //Console.WriteLine(GetAuthorNamesEndingIn(db,ending)); //7. Author Search

                //var containing = Console.ReadLine().ToLower(); //8. Book Search
                //Console.WriteLine(GetBookTitlesContaining(db, containing)); //8. Book Search

                //var ending = Console.ReadLine(); //9. Book Search by Author
                //Console.WriteLine(GetBooksByAuthor(db, ending)); //9. Book Search by Author

                //var lengthCheck = int.Parse(Console.ReadLine()); //10. Count Books
                //Console.WriteLine(CountBooks(db,lengthCheck)); //10. Count Books

                //Console.WriteLine(CountCopiesByAuthor(db)); //11. Total Book Copies

                //Console.WriteLine(GetTotalProfitByCategory(db)); //12. Profit by Category

                //Console.WriteLine(GetMostRecentBooks(db)); //13. Most Recent Books

                //Console.WriteLine(IncreasePrices(db)); //14. Increase Prices

                //Console.WriteLine(RemoveBooks(db)); //15. Remove Books
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            var removedBook = books.Count();

            context.Books.RemoveRange(books);
            context.SaveChanges();
            return removedBook;
        }

        public static int IncreasePrices(BookShopContext context)
        {
            var bookBefore2010 = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            bookBefore2010.ForEach(b => b.Price += 5);

            return context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .Select(cb => new
                        {
                            Title = cb.Book.Title,
                            Date = cb.Book.ReleaseDate.Value
                        })
                        .OrderByDescending(b => b.Date)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            var output = new StringBuilder();

            foreach (var c in categories)
            {
                output.AppendLine($"--{c.Name}");
                foreach (var b in c.Books)
                {
                    output.AppendLine($"{b.Title} ({b.Date.Year})");
                }
            }

            return output.ToString();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Profit = c.CategoryBooks
                        .Select(cb => cb.Book)
                        .Select(b => b.Price * b.Copies)
                        .Sum()
                })
                .OrderByDescending(c=>c.Profit)
                .ThenBy(c=>c.CategoryName)
                .ToList();

            var output = string.Join(Environment.NewLine, categories.Select(c => $"{c.CategoryName} ${c.Profit:f2}"));

            return output;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    Name=$"{a.FirstName} {a.LastName}",
                    Copies=a.Books.Sum(b=>b.Copies)
                })
                .OrderByDescending(a=>a.Copies)
                .ToList();

            var output = string.Join(Environment.NewLine, authors.Select(a => $"{a.Name} - {a.Copies}"));

            return output;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Select(b => b.Title)
                .Where(b => b.Length > lengthCheck)
                .ToList();

            var output = books.Count;

            return output;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Include(b => b.Author)
                .Where(b => b.Author.LastName.IndexOf(input,StringComparison.OrdinalIgnoreCase)==0)
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList();

            var output = string.Join(Environment.NewLine, books);

            return output;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var output = string.Join(Environment.NewLine, books);

            return output;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a)
                .ToList();

            var output = string.Join(Environment.NewLine, authors);

            return output;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToList();

            var output = string.Join(Environment.NewLine, books);

            return output;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var genres = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    CategoryName = b.BookCategories
                        .Select(bc => bc.Category.Name)
                        .SingleOrDefault()
                })
                .Where(b => genres.Any(g => g.ToLower() == b.CategoryName.ToLower()))
                .OrderBy(b => b.Title)
                .ToList();

            var output = string.Join(Environment.NewLine, books.Select(b => b.Title));

            return output;
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var bookTitlesNotInYear = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var output = string.Join(Environment.NewLine, bookTitlesNotInYear);

            return output;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksWithPrices = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:f2}")
                .ToList();

            var output = string.Join(Environment.NewLine, booksWithPrices);

            return output;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooksTitles = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var output = string.Join(Environment.NewLine, goldenBooksTitles);

            return output;
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();


            var output = string.Join($"{Environment.NewLine}", books);

            return output;
        }
    }
}
