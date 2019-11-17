using System;

namespace CsharpAdvancedMosh.Delegates
{
    class PhotoProcessor
    {
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

            filterHandler(photo);

            photo.Save();
        }

        //.NET delegate Action
        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }
    }
}
