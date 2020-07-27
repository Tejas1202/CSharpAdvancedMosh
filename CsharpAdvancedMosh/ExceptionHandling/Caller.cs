using System;
using System.IO;

namespace CsharpAdvancedMosh.ExceptionHandling
{
    class Caller
    {
        public void Call()
        {
            BasicExceptionHandlingExample();

            FinallyBlockExample();

            CustomExceptionExample();
        }

        private static void BasicExceptionHandlingExample()
        {
            try
            {
                var calculator = new Calculator();
                var result = calculator.Divide(5, 0);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("You cannot divide by zero");
            }
            catch (ArithmeticException)
            {

            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, an unexpected error occurred");
            }
        }

        private static void FinallyBlockExample()
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(@"C:\file.zip");
                var content = streamReader.ReadToEnd();
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, an unexpected error occurred");
            }
            finally
            {
                //If anything goes wrong in the try block, we wanna make sure that the stream is closed which is extremely important
                //otherwise we may keep open files, network/database connections and we may run out of resources
                if (streamReader != null)
                    streamReader.Dispose(); //Calling the Dispose method of IDisposable interface
            }

            #region Shorter way of writing the above code with "using", so we don't can declare a more local variable and don't have to write finally block
            try
            {
                //Internally compiler will create finally block under the hood
                //and will call Dispose method once it's job is done
                using (var streamRead = new StreamReader(@"C:\file.zip"))
                {
                    var content = streamRead.ReadToEnd();
                }
            }
            catch
            {
                Console.WriteLine("Sorry, an unexpected error occurred");
            }
            #endregion
        }

        private static void CustomExceptionExample()
        {
            try
            {
                var api = new YoutubeApi();
                api.GetVideos("tejas");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
