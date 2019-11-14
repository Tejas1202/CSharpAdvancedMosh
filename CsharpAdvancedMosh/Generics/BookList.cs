using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvancedMosh.Generics
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

    public class Book : Product
    {
        public string IsBn { get; set; }
    }
}
