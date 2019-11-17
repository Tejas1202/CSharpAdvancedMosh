using System;

namespace CsharpAdvancedMosh.Generics.BeforeGenericsCame
{
    //So for every new type we'd to create new classes earlier when generics wasn't introduced
    class BookList
    {
        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public Book this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class Book
    {
        public string IsBn { get; set; }
    }
}
