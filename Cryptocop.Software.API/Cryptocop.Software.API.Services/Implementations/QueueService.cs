﻿using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using Newtonsoft.Json.Serialization;


namespace Cryptocop.Software.API.Services.Implementations
{
    //notes fyrir order
    //bæta ollum order items í gagnagrunninn í for each loopunni
    //bua svo til lista fyrir order entity
    public class QueueService : IQueueService, IDisposable
    {
    
    private IConnection connection;
    private IModel channel;

    private ConnectionFactory factory;

    public QueueService()
    {
            factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
    }

    public void PublishMessage(string routingKey, object body)
        {
            
        
            channel.ExchangeDeclare(exchange: "order", type: ExchangeType.Fanout);
            

            var body2 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body));
            channel.BasicPublish(exchange: "order",
                                routingKey: routingKey,
                                mandatory: true,
                                basicProperties: null,
                                body: body2);
                
            
       
        }

        public void Dispose()
        {
            
            channel.Close();
            connection.Close();
          
        }
    }
}