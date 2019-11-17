using System;

namespace CsharpAdvancedMosh.Generics.Constraints
{
    //Constraints: IComparable (applying Constraint to an interface), new() (for default constructors)

    class Utilities<T> where T : IComparable, new()
    {
        #region Just like we compare two integers here, if we wanna compare two objects, than we can't do it without any constraints
        //Just like we compare two integers here
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        //Compile time error, as compiler considers both T's as objects hence we aren't able to compare
        //At that time, we need to use constraints  (we want to assume that both a and b will implement the IComparable interface, which provides CompareTo method)
        //public T Max<T>(T a, T b)
        //{
        //    return a > b > a : b;
        //}
        #endregion

        #region Applying Constraints
        //If we don't want to define Type at class level, just want to define at method level
        public U Max<U>(U a, U b) where U : IComparable
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        //We defined type at class level, so no need to do Max<T> and apply constraint here
        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        //When we want to create an instance of T
        public void DoSomething(T value)
        {
            //cannot create a new obj to type T as at this time because compiler doesn't know what type T is referring to, and we need a default constructor
            //so we implement new() as constraint
            var obj = new T();
        }
        #endregion
    }
}
