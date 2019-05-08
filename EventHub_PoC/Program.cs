using EventHub_PoC.Receiver;
using System;

namespace EventHub_PoC
{
    class Program
    {
        static void Main(string[] args)
        {           
            //SampleSender.MainAsync().GetAwaiter().GetResult();
            SampleEHReceiver.EventReceiverHost().GetAwaiter().GetResult();
        }
    }
}
