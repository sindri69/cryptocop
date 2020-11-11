using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class QueueService : IQueueService, IDisposable
    {
        public void PublishMessage(string routingKey, object body)
        {
            Console.WriteLine("Start of publishMessage");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "order", type: ExchangeType.Fanout);

                var body2 = Encoding.UTF8.GetBytes(body.ToString());
                channel.BasicPublish(exchange: "order",
                                    routingKey: routingKey,
                                    mandatory: true,
                                    basicProperties: null,
                                    body: body2);
                
            }
            Console.WriteLine("end of publishmessage");
        }

        public void Dispose()
        {
            //channel.Close();
            //conn.Close();
            Console.WriteLine("inside dispose");
        }
    }
}