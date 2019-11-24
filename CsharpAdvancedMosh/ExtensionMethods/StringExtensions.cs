using System.Linq;

//Defining our method in the System namespace itself as we're extending String class which is of System namespace
//In this way, whenever an instance of String class is created, our extension method becomes directly accessible even if the caller is in different namespace
//from where the extension method has been defined
namespace System
{
    public static class StringExtensions
    {
        public static string Shorten(this string str, int numberOfWords)
        {
            if (numberOfWords < 0)
                throw new ArgumentOutOfRangeException("numberOfWords should be greater than or equal to zero");

            if (numberOfWords == 0)
                return "";

            var words = str.Split(' ');

            if (words.Length <= numberOfWords)
                return str;

            //Take is an extension method that can be applied on any class that implements IEnumberable interface
            //In this case Take method is applied on string array
            return string.Join(" ",words.Take(numberOfWords)) + "...";
        }
    }
}
