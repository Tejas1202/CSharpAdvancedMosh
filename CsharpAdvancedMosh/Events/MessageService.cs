using System;

namespace CsharpAdvancedMosh.Events
{
    //Subscriber
    class MessageService
    {
        public void OnVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("MessageService: Sending a text message...");
        }
    }
}
