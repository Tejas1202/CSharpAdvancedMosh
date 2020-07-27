using System.Collections.Generic;

namespace CsharpAdvancedMosh.Delegates.UsingInterface
{
    class PhotoProcessor
    {
        private readonly IList<IPhotoFilter> _photoFiltersList = new List<IPhotoFilter>();

        public void Process(Photo photo)
        {
            foreach(var filter in _photoFiltersList)
            {
                filter.ApplyFilter(photo);
            }
        }

        public void AddFilters(IPhotoFilter photoFilter)
        {
            _photoFiltersList.Add(photoFilter);
        }
    }
}
