using System.Collections.Generic;

namespace CsharpAdvancedMosh.LambdaExpressions
{
    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book{Title = "Title 1", Price = 5},
                new Book{Title = "Title 2", Price = 7},
                new Book{ Title = "Title 3", Price = 15}
            };
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public int Price { get; set; }
    }
}
