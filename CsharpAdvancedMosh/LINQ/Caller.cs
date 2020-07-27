using System;
using System.Linq; // For accessing LINQ extension methods on Collections

namespace CsharpAdvancedMosh.LINQ
{
    class Caller
    {
        public void Call()
        {
            var books = new BookRepository().GetBooks();

            #region finding cheap books without LINQ
            //var cheapBooks = new List<Book>();
            //foreach(var book in books)
            //{
            //    if (book.Price < 10)
            //        cheapBooks.Add(book);
            //}
            #endregion

            // So here it's LINQ to objects i.e. Querying objects (here Collections) directly in memory
            #region finding cheap books with LINQ (Where extension method expecting a Func which is supplied through lambda expression)
            //We can also chain LINQ methods
            //LINQ Extension Methods
            var cheapBooks = books
                                .Where(b => b.Price < 10)
                                .OrderBy(b => b.Title)
                                .Select(b => b.Title);
            #endregion

            //LINQ Query Operators (Most of the time we'll use LINQ Extension Methods as it is more clean to read
            //than LINQ Query Operators. Every keyword actually maps to extension methods so there's no right or
            //wrong on what to use. But there are some cases where we don't have a keyword for every extension method
            var cheaperBooks =
                from b in books // LINQ query operators always starts with from
                where b.Price < 10
                orderby b.Title
                select b; // and they must end with a select/group clause

            Console.WriteLine("Cheap books");
            foreach(var item in cheapBooks)
                Console.WriteLine(item);
            //Console.WriteLine(book.Title + " " + book.Price);

            //Some other extension methods

            // Single: To fetch only one item from the collection based on condition
            //books.Single will throw directly an exception if that particular book is not found
            //SingleOrDefault will return null in that case
            var book = books.SingleOrDefault(b => b.Title == "ASP.NET MVC++");
            Console.WriteLine(book?.Title);

            // Returns first item, optionally takes a delegate Func which implies return the first item that satisfies this condition
            // FirstOrDefault used for similar Exception reasons
            var firstBook = books.First(b => b.Title == "C# Advanced Topics");
            Console.WriteLine("First");
            Console.WriteLine(firstBook.Title + " " + firstBook.Price);

            var lastBook = books.LastOrDefault(b => b.Title == "C# Advanced Topics");
            Console.WriteLine("LastOrDefault");
            Console.WriteLine(lastBook.Title + " " + lastBook.Price);

            // Skip and Take are used often for pagination
            var pagedBooks = books.Skip(2).Take(3);
            Console.WriteLine("Skip 2 and Take 3");
            foreach(var item in pagedBooks)
                Console.WriteLine(item.Title + " " + item.Price);

            // Aggregate functions in LINQ
            var maxPrice = books.Max(b => b.Price);
            var minPrice = books.Min(b => b.Price);
            var totalPrices = books.Sum(b => b.Price);
            Console.WriteLine("Aggregate functions");
            Console.WriteLine("Max: {0}, Min: {1}, Sum: {2}", maxPrice, minPrice, totalPrices);
        }
    }
}
