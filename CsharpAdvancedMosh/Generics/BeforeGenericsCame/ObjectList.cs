using System;

namespace CsharpAdvancedMosh.Generics.BeforeGenericsCame
{
    //But here, with the Object list also, there are performance issues
    //Boxing and unboxing will happen while dealing with value types
    //Required casting will happen when dealing with reference types
    //So generics came as a solution
    class ObjectList
    {
        public void Add(Object value)
        {

        }

        public object this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
