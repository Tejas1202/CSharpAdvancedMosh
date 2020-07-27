using System;

namespace CsharpAdvancedMosh.LambdaExpressions
{
    class Caller
    {
        public void Call()
        {
            Console.WriteLine(Sqaure(5));

            // args => expression
            //number => number * number; //As writing only this will give compiler error, we'll assign this to a delegate

            //Func<int, int> sqaure = Sqaure; //Instead of pointing our delegate to Sqaure method, we can directly use lambda expression
            Func<int, int> square = number => number * number;

            Console.WriteLine(square(5));

            const int factor = 5;
            Func<int, int> multiplier = n => n * factor;

            Console.WriteLine(multiplier(10));

            var books = new BookRepository().GetBooks();
            Predicate<Book> predicate = IsCheaperThanTenDollars;
            // FindAll and many other methods in Generic list takes argument Predicate (delegate who takes a argument and returns bool based on condition)
            // FindAll will iterate the list and call the method one by one
            var cheapBooks = books.FindAll(predicate); //Pass IsCheaperThanTenDollars directly here, passing the predicate here was just for the sake of understanding delegates
            foreach(var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }
            //Now the problem with the above code is, everytime even for a slight change in condition, we'll need to define a new Method (e.g finding expensive books)
            //Hence in that case, lambda expressions comes in handy
            // Also we aren't using this method anywhere else, so better to use lambda expression in that case to use less code and achieve the same thing

            //Using lambda expression
            cheapBooks = books.FindAll(b => b.Price < 10);
            foreach(var book in cheapBooks)
                Console.WriteLine(book.Title);
        }

        //Func<in T, out Tresult> method signature
        static int Sqaure(int number)
        {
            return number * number;
        }

        //Predicate method signature (Takes T obj and returns bool based on condition)
        // If lambda expression wasn't there, then we've to define this method everytime
        static bool IsCheaperThanTenDollars(Book book)
        {
            return book.Price < 10;
        }

    }
}
