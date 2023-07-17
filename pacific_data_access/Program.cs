
using System;
using System.Text;
using Contracts;
using RabbitMQ.Client;

namespace pacific_data_access
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "", UserName = "", Password = "", VirtualHost = ""};
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            // channel.QueueDeclare(queue: "PayPacketClosedEventV1Handler",
            //     durable: false,
            //     exclusive: false,
            //     autoDelete: false,
            //     arguments: null);

            // const string message = "Hello World!";
            PayRunClosedEvent_v1 message = new PayRunClosedEvent_v1{PayRunId = 1};
            string jsonMessage = Newtonsoft.Json.JsonConvert.SerializeObject(message);
            
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            channel.BasicPublish(exchange: string.Empty,
                routingKey: "PayPacketClosedEventV1Handler",
                basicProperties: null,
                body: body);
            Console.WriteLine($" [x] Sent {message}");

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
