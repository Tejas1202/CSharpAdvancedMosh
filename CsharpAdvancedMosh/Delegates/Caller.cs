using CsharpAdvancedMosh.Delegates.UsingInterface.PhotoFilters;
using System;
using System.Runtime.InteropServices;

namespace CsharpAdvancedMosh.Delegates
{
    class Caller
    {
        public void Call()
        {
            //Without delegates (hence not extensible if we want to apply our own filter as we'll need to change PhotoProcessor class)
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

            UsingInterfaces();
        }

        //Developer adding new filter which was not part of the framework and it shoould comply with the delegate signature
        //PhotoProcessor and PhotoFilters classes still left unchanged. Hence extensibility achieved
        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply remove redeye");
        }

        #region extensibility using Interface instead of delegates to acheive the same thing
        private void UsingInterfaces()
        {
            var photoProcessor = new UsingInterface.PhotoProcessor();
            photoProcessor.AddFilters(new BrightnessFilter());
            photoProcessor.AddFilters(new ContrastFilter());
            photoProcessor.Process(new Photo());
        }
        #endregion
    }
}
