using System;

namespace CsharpAdvancedMosh.ExceptionHandling
{
    class YoutubeException : Exception
    {
        public YoutubeException(string message, Exception innerException)
            : base(message,innerException)
        {

        }
    }
}
