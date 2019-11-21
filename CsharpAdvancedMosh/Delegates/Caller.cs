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
            PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness; //Creating an instance of delegate and pointing it to a method having same signature
            filterHandler += filters.ApplyContrast; //As our delegate here is pointing to multiple functions, so this is a multicaste delegate
            filterHandler += RemoveRedEyeFilter;           
            photoProcessor.Process("photo.jpg", filterHandler);

            //With .NET delegates
            Action<Photo> actionFilterHandler = filters.ApplyBrightness;
            actionFilterHandler += filters.ApplyContrast;
            photoProcessor.Process("photo.jpg", actionFilterHandler);
            Action<Photo> action = new Action<Photo>(filters.ApplyBrightness); //Can also call in this way
            action(new Photo());
        }

        //Developer adding new filter which was not part of the framework
        //PhotoProcessor and PhotoFilters classes still left unchanged. Hence extensibility achieved
        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply remove redeye");
        }
    }
}
