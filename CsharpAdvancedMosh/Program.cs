namespace CsharpAdvancedMosh
{
    class Program
    {
        static void Main(string[] args)
        {
            var genericsCaller = new Generics.Caller();
            genericsCaller.Call();

            var delegatesCaller = new Delegates.Caller();
            delegatesCaller.Call();

            var lambdaCaller = new LambdaExpressions.Caller();
            lambdaCaller.Call();

            var eventsCaller = new Events.Caller();
            eventsCaller.Call();

            var extensionMethodsCaller = new ExtensionMethods.Caller();
            extensionMethodsCaller.Call();

            var linqCaller = new LINQ.Caller();
            linqCaller.Call();

            var nullableTypesCaller = new NullableTypes.Caller();
            nullableTypesCaller.Call();

            var dynamicCaller = new Dynamic.Caller();
            dynamicCaller.Call();

            var exceptionHandlingCaller = new ExceptionHandling.Caller();
            exceptionHandlingCaller.Call();
        }
    }
}
