using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;
using CreditCardValidator;


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
                Console.WriteLine("Recieving data...");
                byte[] body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var result = JsonConvert.DeserializeObject<OrderDto>(message);
                //Console.WriteLine(result.CreditCard);

                //validate credit card
                CreditCardDetector detector = new CreditCardDetector(result.CreditCard);
                if(detector.IsValid())  {Console.WriteLine("This CreditCard number is valid");}
                else                    {Console.WriteLine("This CreditCard number is invalid");}
            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }

    }
     public class OrderDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string StreetName { get; set; }

        public string HouseNumber {get; set;}

        public string ZipCode {get; set;}

        public string Country {get; set;}

        public string City {get; set;}

        public string CardholderName {get; set;}

        public string CreditCard {get; set;}

        public string OrderDate {get; set; }
        //• Represented as 01.01.2020

        public float? TotalPrice {get; set;}

        //public List<OrderItemDto> OrderItems {get; set; }
        //vantar using orderitemdto?
        //spurning hvort þetta sé rétt týpa af lista til að nota

    }

}
