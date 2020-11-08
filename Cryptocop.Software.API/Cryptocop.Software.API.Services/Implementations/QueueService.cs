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
            
            /*var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

                var body2 = Encoding.UTF8.GetBytes(body);
                channel.BasicPublish(exchange: "order",
                                    routingKey: routingKey,
                                    basicProperties: null,
                                    body: body2);
                
            }*/
        }

        public void Dispose()
        {
            // TODO: Dispose the connection and channel
            throw new NotImplementedException();
        }
    }
}