namespace CsharpAdvancedMosh.Dynamic
{
    class Caller
    {
        public void Call()
        {
            object obj = "Mom";
            //obj.GetHashCode();
            //Calling GetHashCode method with Reflection which is very difficult and messy
            var methodInfo = obj.GetType().GetMethod("GetHashCode");
            methodInfo.Invoke(null, null);

            //Benefits of using dynamic example
            //let's say we're getting an excel object and we know that at runtime, that object should've a method named Optimize
            //But we cannot call Optimize on object but obviously as object has it's only default methods
            //That's where we use dynamic
            dynamic excelObject = "mom"; //object excelObject = "mom";
            excelObject.Optimize();
            //So with dynamic, it's much cleaner than Reflection

            dynamic name = "Mosh";
            //name++; //Will throw an RuntimeBinder exception as it is a string type
            name = 10;
            dynamic a = 10;
            dynamic b = 5;
            var c = a + b;

            int i = 5;
            dynamic d = i;
            long l = d; //We can get a implicit conversion here as our dynamic here is int
            byte @byte = d; //But here, it will throw an exception at runtime of explicit conversion
        }
    }
}
