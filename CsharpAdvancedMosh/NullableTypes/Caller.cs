using System;

namespace CsharpAdvancedMosh.NullableTypes
{
    class Caller
    {
        public void Call()
        {
            DateTime? date = null; //<= shorter way to define nullables instead of => Nullable<DateTime> date = null;
            Console.WriteLine(date.GetValueOrDefault());
            Console.WriteLine(date.HasValue);
            //Console.WriteLine(date.Value); //Will throw an exeption here as we've assigned null value to our variable

            date = new DateTime(1966, 6, 3);
            DateTime dateTwo = date.GetValueOrDefault(); //As we cannot assign Nullable to Non-nullable datetime directly
            DateTime? dateThree = dateTwo; //But non-nullable to nullable don't need a conversion
            Console.WriteLine(dateThree);

            //Null coalescing operator, shorter way of ternary (the difference being the condition it always checks for is null)
            date = null;
            DateTime dateFour = date ?? DateTime.Today;
            Console.WriteLine(dateFour);
        }
    }
}
