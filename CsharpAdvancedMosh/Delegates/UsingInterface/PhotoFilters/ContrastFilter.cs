using System;

namespace CsharpAdvancedMosh.Delegates.UsingInterface.PhotoFilters
{
    class ContrastFilter : IPhotoFilter
    {
        public void ApplyFilter(Photo photo)
        {
            Console.WriteLine("Apply Contrast");
        }
    }
}
