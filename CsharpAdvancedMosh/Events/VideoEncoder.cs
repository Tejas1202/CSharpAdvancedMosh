using System;
using System.Threading;

namespace CsharpAdvancedMosh.Events
{
    class VideoEncoder
    {
        //Steps to give VideoEncoder the ability to raise an event
        // 1- Define a delegate (Contract bw the publisher and subscriber. Delegate determines the signature of the method in the
        //    subscriber that will be called when the publisher publishes an event
        // 2- Define an event based on that delegate
        // 3- Raise the event

        /// <summary>
        /// 1 - Defining contract
        /// </summary>
        /// <param name="source">source of the event(class that is publishing the event)</param>
        /// <param name="args">any additional data that we want to send with the event</param>
        public delegate void VideoEncodedEventHandler(object source, EventArgs args); //Naming => EventName(i.e. VideoEncoded) + EventHandler

        /// <summary>
        /// 2- Defining event based on delegate
        /// </summary>
        public event VideoEncodedEventHandler VideoEncoded; // Naming => done in past tense as event is raised after Video Encoded
        
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded();
        }

        /// <summary>
        /// 3- To raise an event, we need a method that is responsible for that
        /// Acc. to .NET convention, your event publisher methods should be protected, virtual and void
        /// Naming convention => Start with On + Name of the event
        /// </summary>
        protected virtual void OnVideoEncoded()
        {
            VideoEncoded?.Invoke(this, EventArgs.Empty); //Short for if(VideoEncoded != null) { VideoEncoded(this, EventArgs.Empty)
        }

        //Calling event handlers directly via delegate to see the difference
        //Here, the client do have the flexibility to pass null and subscribers can also interfere with one another
        public void Encode(Video video, VideoEncodedEventHandler videoEncodedEventHandler)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            videoEncodedEventHandler(this, EventArgs.Empty);
        }
        
    }
    
}
