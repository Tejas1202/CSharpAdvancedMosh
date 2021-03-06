﻿using System;
using CsharpAdvancedMosh.Generics.BeforeGenericsCame;

namespace CsharpAdvancedMosh.Generics
{
    using CsharpAdvancedMosh.Generics.Constraints; //To call Custom defined Nullable instead of .NET one, we defined using here

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

            var numberTwo = new Nullable<int>();
            Console.WriteLine("Has value? " + numberTwo.HasValue);
            Console.WriteLine("Value: " + numberTwo.GetValueOrDefault());
        }
    }
}
