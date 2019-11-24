using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvancedMosh.LINQ
{
    class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book{Title = "C# Basics" , Price = 8},
                new Book{Title = "ADO.NET Step by Step", Price = 5},
                new Book{Title = "ASP.NET MVC", Price = 9.99f},
                new Book{Title = "ASP.NET Web API", Price = 12},
                new Book{Title = "C# Advanced Topics", Price = 7},
                new Book{Title = "C# in Depth", Price = 20},
                new Book{Title = "C# Advanced Topics", Price = 10}
            };
        }
    }
}
