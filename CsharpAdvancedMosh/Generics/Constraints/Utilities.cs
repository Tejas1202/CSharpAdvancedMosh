using System;

namespace CsharpAdvancedMosh.Generics.Constraints
{
    //Constraint: IComparable

    class Utilities<T> where T : IComparable, new()
    {
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        //Compile time error, as compiler considers both T's as objects hence we are'nt able to compare
        //At that time, we need to use constraints  (we want to assume that both a and b will implement the IComparable interface, which provides CompareTo method)
        //public T Max<T>(T a, T b)
        //{
        //    return a > b > a : b;
        //}

        //Applying Constraints
        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public void DoSomething(T value)
        {
            var obj = new T(); //cannot create a new obj to type T until we implement new() as interface
        }
    }
}
