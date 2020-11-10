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
        private readonly IQueueService _queueService;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public OrderService(IOrderRepository orderRepository, IQueueService queueService, IShoppingCartRepository shoppingCartRepository)
        {
        _orderRepository = orderRepository;
        _queueService = queueService;
        _shoppingCartRepository = shoppingCartRepository;
        }

        public IEnumerable<OrderDto> GetOrders(string email)
        {
            return _orderRepository.GetOrders(email);
        }

        public void CreateNewOrder(string email, OrderInputModel order)
        {
            //create order with repository class
            var createdOrder = _orderRepository.CreateNewOrder(email, order);

            // //delete current shopping cart
            _shoppingCartRepository.DeleteCart(email);

            // //publish message to RabbitMQ with routing key create-order
            _queueService.PublishMessage("create-order", createdOrder);

        }
    }
}

