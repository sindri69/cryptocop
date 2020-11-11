﻿using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;


namespace cryptocop_payments
{
    class Program
    {    public static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.ExchangeDeclare(exchange: "order", type: ExchangeType.Fanout);

            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName, exchange: "order", routingKey: "create-order");

            Console.WriteLine(" [*] Waiting for logs.");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                Console.WriteLine("something was recieved");
                Console.WriteLine("1");
                byte[] body = ea.Body.ToArray();
                Console.WriteLine("1");
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("1");
                var data = JsonConvert.DeserializeObject(message);
                Console.WriteLine("1");
                Console.WriteLine(" [HERE] {0}", data);
                Console.WriteLine(data);
                //var result = JsonConvert.DeserializeObject<OrderDto>(data);
                //Console.WriteLine(result);

            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }

    }


    //     public class OrderDto
    // {
    //     public int Id { get; set; }

    //     public string Email { get; set; }

    //     public string FullName { get; set; }

    //     public string StreetName { get; set; }

    //     public string HouseNumber {get; set;}

    //     public string ZipCode {get; set;}

    //     public string Country {get; set;}

    //     public string City {get; set;}

    //     public string CardholderName {get; set;}

    //     public string CreditCard {get; set;}

    //     public string OrderDate {get; set; }
    //     //• Represented as 01.01.2020

    //     public float? TotalPrice {get; set;}

    //     //public List<OrderItemDto> OrderItems {get; set; }
    //     //vantar using orderitemdto?
    //     //spurning hvort þetta sé rétt týpa af lista til að nota

    // }
}
