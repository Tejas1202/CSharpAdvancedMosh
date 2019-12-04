using System;
using System.Collections.Generic;

namespace CsharpAdvancedMosh.ExceptionHandling
{
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
