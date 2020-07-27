using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpAdvancedMosh.ExtensionMethods
{
    class Caller
    {
        public void Call()
        {
            string post = "This is supposed to be a very long blog post etc. etc. etc. ...";
            var shortenPost = post.Shorten(5); //As we cannot derive from sealed class string, hence making an extension method
            Console.WriteLine(shortenPost);

            // There are many other many extension methods like Where, Select in System.Linq namespace which extends classes deriving from IEnumerables
            // Hence Linq extends the capabilites of collections by his extension methods
            IEnumerable<int> numbers = new List<int> { 1,2 ,5 ,18, 10};
            var max = numbers.Max(); //extension method Max in Linq namespace
            Console.WriteLine(max);
        }
    }
}
