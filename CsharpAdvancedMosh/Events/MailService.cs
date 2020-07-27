using CsharpAdvancedMosh.Events.SendingEventArgs;
using System;

namespace CsharpAdvancedMosh.Events
{
    //Subscriber
    class MailService
    {
        //Event handler (defining signature of method based on the contract i.e. delegate)
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("MailService: Sending an Email...");
        }

        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MailService: Sending an Email " + e.Video.Title);
        }
    }
}
