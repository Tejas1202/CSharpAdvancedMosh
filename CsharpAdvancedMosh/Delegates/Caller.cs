using System;

namespace CsharpAdvancedMosh.Delegates
{
    class Caller
    {
        public void Call()
        {
            //Without delegates
            var photoProcessor = new PhotoProcessor();
            photoProcessor.Process("photo.jpg");

            //With custom delegates
            var filters = new PhotoFilters();
            PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;           
            photoProcessor.Process("phpto.jpg", filterHandler);

            //With .NET delegates
            Action<Photo> actionFilterHandler = filters.ApplyBrightness;
            actionFilterHandler += filters.ApplyContrast;
            photoProcessor.Process("photo.jpg", actionFilterHandler);
        }

        //Developer adding new filter which was not part of the framework
        //PhotoProcessor and PhotoFilters classes still left unchanged. Hence extensibility achieved
        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply remove redeye");
        }
    }
}
