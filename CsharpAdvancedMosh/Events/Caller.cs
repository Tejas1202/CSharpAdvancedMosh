namespace CsharpAdvancedMosh.Events
{
    class Caller
    {
        public void Call()
        {
            var video = new Video { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); //publisher
            var mailService = new MailService(); //subscriber
            var messageService = new MessageService(); //subscriber
            
            //Without any EventArgs
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; //Now we are not doing OnVideoEncoded() as we're not calling the method, just used the name
            //which means this is a reference/pointer to that method. Hence VideoEncoded event behind the scenes is a list of pointers to methods
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            videoEncoder.VideoEncoded += null;
            // Hence we added subscribers to the event before calling/starting Encode
            videoEncoder.Encode(video);

            //Sending EventArgs to the subscribers
            var videoEncoderWithArgs = new SendingEventArgs.VideoEncoder();
            videoEncoderWithArgs.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoderWithArgs.Encode(video);

            //Calling directly via delegate
            VideoEncoder.VideoEncodedEventHandler videoEncodedEventHandler = mailService.OnVideoEncoded;
            videoEncodedEventHandler += messageService.OnVideoEncoded;
            videoEncodedEventHandler = null; //Delegates can be assigned null directly which is not what we want
            videoEncoder.Encode(video, videoEncodedEventHandler);
        }
    }
}
