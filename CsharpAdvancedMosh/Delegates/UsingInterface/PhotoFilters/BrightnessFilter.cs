using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvancedMosh.Delegates.UsingInterface.PhotoFilters
{
    class BrightnessFilter : IPhotoFilter
    {
        public void ApplyFilter(Photo photo)
        {
            Console.WriteLine("Apply Brightness");
        }
    }
}
