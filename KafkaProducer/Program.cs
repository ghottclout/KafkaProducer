using System;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;

namespace KafkaProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new KafkaOptions
               (new Uri("http://localhost:9092")
                );
            var router = new BrokerRouter(options);

            var client = new KafkaNet.Producer(router);

            for(int i = 0; i < 10; i++)
            {
                client.SendMessageAsync("TestTopic", new[]
                   { new Message(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + " | Producer Console | " + i) }).Wait();
            }

            Console.ReadLine();
        }
    }
}