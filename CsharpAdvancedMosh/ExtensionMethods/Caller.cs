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

            IEnumerable<int> numbers = new List<int> { 1,2 ,5 ,18, 10};
            var max = numbers.Max(); //extrnsion method Max in Linq namespace
            Console.WriteLine(max);
        }
    }
}
