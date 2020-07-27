using System;
using System.Collections.Generic;

namespace CsharpAdvancedMosh.ExceptionHandling
{
    // We might not want our other classes in the application to get lower level exceptions from the Youtube Api directly,
    // hence in that case, we can create CustomExceptions in which lower level exceptions can be wrapped
    class YoutubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                //Access Youtube web service
                //Read the data
                //Create a list of Video objects
                throw new Exception("Oops some low level Youtube error");
            }
            catch(Exception ex)
            {
                //Log that exception
                //Wrapping our exception ex inside YoutubeException class.
                //Hence when this exception throws, we're gonna get Innerexception as the exception thrown above
                throw new YoutubeException("Could not fetch the videos from Youtube", ex);
            }

            return new List<Video>();
        }
    }

    public class Video
    {

    }

}
