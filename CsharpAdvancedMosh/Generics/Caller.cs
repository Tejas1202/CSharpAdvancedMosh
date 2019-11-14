using System;

namespace CsharpAdvancedMosh.Generics
{
    class Caller
    {
        public void Call()
        {
            #region older versions without generics, code redundancy
            var numbers = new List();
            numbers.Add(2);

            var booksList = new BookList();
            booksList.Add(new Book());
            #endregion

            var numbersList = new GenericList<int>();
            numbers.Add(10);

            var books = new GenericList<Book>();
            books.Add(new Book());

            var dictionary = new GenericDictionary<string, Book>();
            dictionary.Add("1234", new Book());

            var number = new Nullable<int>(5);
            Console.WriteLine("Has value? " + number.HasValue);
            Console.WriteLine("Value: " + number.GetValueOrDefault());
        }
    }
}
