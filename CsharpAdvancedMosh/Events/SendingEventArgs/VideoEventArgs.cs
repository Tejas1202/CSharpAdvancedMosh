using System;
using System.Threading;

namespace CsharpAdvancedMosh.Events.SendingEventArgs
{
    // Now we want to send a reference to the video, so that the subscriber knows which video we encoded
    // To do that, we need custom class instead of EventArgs and it should derive from EventArgs
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; } //determines the video that was encoded
    }

    public class VideoEncoder
    {
        public delegate void VideoEncoderEventHandler(object source, VideoEventArgs args);

        // Note: Here also no need to define custom delegates for event handler as there's already EventHandler<T> for it
        // If we don't want to pass any event args, then we can just use EventHandler
        // public event EventHandler<VideoEventArgs> VideoEncoded;

        public event VideoEncoderEventHandler VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            VideoEncoded?.Invoke(this, new VideoEventArgs { Video = video});
        }

    }
}
