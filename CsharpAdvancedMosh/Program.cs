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
        }
    }
}
