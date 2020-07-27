using System;

namespace CsharpAdvancedMosh.Delegates
{
    class PhotoProcessor
    {
        // Define delegate: Need to define the signature of the method that this delegate will be responsible for calling
        // So here our delegate is PhotoFilterHandler and an instance of this delegate can hold a reference to a function/group of functions that have this signature
        public delegate void PhotoFilterHandler(Photo photo);

        //Now this piece of code has a problem (it's not extensible)
        //If you provide a framework for processing photos, and suppose a developer using this framework wants to apply a new filter
        //Then you've to create that filter, and recompile and redeploy your code
        //So this problem can be solved with delegates to make this framework extensible
        public void Process(string path)
        {
            var photo = Photo.Load(path);

            var filters = new PhotoFilters();
            filters.ApplyBrightness(photo);
            filters.ApplyContrast(photo);
            filters.Resize(photo);

            photo.Save();
        }
        
        //Now this method doesn't know what filters will be applied, it's the responsibility of client to decide what filters to apply
        //So this framework doesn't have to be recompiled and redeployed for applying new filter/any number of filters which makes it extensible
        public void Process(string path, PhotoFilterHandler filterHandler)
        {
            var photo = Photo.Load(path);

            // Calling the method here through this delegate instance, the caller will pass pointers to method, and we're calling it here like method(args)
            filterHandler(photo);

            photo.Save();
        }

        //.NET generic delegate Action
        // Action<Photo> describes that you can pass any method reference that takes Photo parameter and returns void
        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }
    }
}
