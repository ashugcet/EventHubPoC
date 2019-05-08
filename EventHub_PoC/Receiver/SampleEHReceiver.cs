using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using System;
using System.Threading.Tasks;

namespace EventHub_PoC.Receiver
{
    public class SampleEHReceiver
    {
        private const string EventHubConnectionString = "Endpoint=sb://elk-eventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NSfRLrB3Ewy47Nhj/Kyyu/2D8qKRFKBOFJdN6FFi0xw=";
        private const string EventHubName = "elk-eventhub";
        private const string StorageContainerName = "ashublobcontainer";
        private const string StorageAccountName = "ashuehstorage";
        private const string StorageAccountKey = "p8s+G5qQuUU0vaWJoJCxAuIrL3WCa/OqS4YigoaFNKSLOUTfvw1t5Xtd2A7tpmJDRpOFCvdLC5bI2L6zPpGWFQ==";

        private static readonly string StorageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", StorageAccountName, StorageAccountKey);
        
        public static async Task EventReceiverHost()
        {
            Console.WriteLine("Registering EventProcessor...");

            var eventProcessorHost = new EventProcessorHost(
                EventHubName,
                PartitionReceiver.DefaultConsumerGroupName,
                EventHubConnectionString,
                StorageConnectionString,
                StorageContainerName);

            // Registers the Event Processor Host and starts receiving messages
            await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>();

            Console.WriteLine("Receiving. Press ENTER to stop worker.");
            Console.ReadLine();

            // Disposes of the Event Processor Host
            await eventProcessorHost.UnregisterEventProcessorAsync();
        }
    }
}
