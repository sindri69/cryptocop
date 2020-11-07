using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using RabbitMQ.Client;
using System.Text;
using System;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
        _orderRepository = orderRepository;
        }

        public IEnumerable<OrderDto> GetOrders(string email)
        {
            return _orderRepository.GetOrders(email);
        }

        public void CreateNewOrder(string email, OrderInputModel order)
        {
            //create order with repository class
            // _orderRepository.CreateNewOrder(email, order);

            // //delete current shopping cart

            // //publish message to RabbitMQ with routing key create-order
            // var factory = new ConnectionFactory() { HostName = "localhost" };
            // using(var connection = factory.CreateConnection())
            // using(var channel = connection.CreateModel())
            // {
            // channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);
             
            // var order = GetMessage(args);
            // var body = Encoding.UTF8.GetBytes(order);
            // channel.BasicPublish(exchange: "logs",
            //                       routingKey: "create-order",
            //                       basicProperties: null,
            //                       body: body);
            // Console.WriteLine(" [x] Sent {0}", order);
            // }

            throw new System.NotImplementedException();
        }
    }
}

