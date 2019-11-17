using System;

namespace CsharpAdvancedMosh.LambdaExpressions
{
    class Caller
    {
        public void Call()
        {
            Console.WriteLine(Sqaure(5));

            // args => expression
            //number => number * number;

            //Func<int, int> sqaure = Sqaure; //Instead of pointing to Sqaure method, we can directly use lambda expression
            Func<int, int> square = number => number * number;

            Console.WriteLine(square(10));

            const int factor = 5;
            Func<int, int> multiplier = n => n * factor;

            Console.WriteLine(multiplier(10));

            var books = new BookRepository().GetBooks();
            Predicate<Book> predicate = IsCheaperThanTenDollars;
            var cheapBooks = books.FindAll(predicate); //Pass IsCheaperThanTenDollars directly here, passing the predicate here was just for the sake of understanding delegates
            foreach(var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }

            //Using lambda expression
            cheapBooks = books.FindAll(b => b.Price > 10);
            foreach(var book in cheapBooks)
                Console.WriteLine(book.Title);
        }

        static int Sqaure(int number)
        {
            return number * number;
        }

        //Predicate method
        static bool IsCheaperThanTenDollars(Book book)
        {
            return book.Price < 10;
        }

    }
}
