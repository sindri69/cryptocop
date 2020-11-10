using System;
using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using AutoMapper;
using System.Linq;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Repositories.Helpers;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private IMapper _mapper;

        public OrderRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
        _dbContext = dbContext;
        _mapper = mapper;
        }

        public IEnumerable<OrderDto> GetOrders(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) {throw new Exception("Something went wrong with the database");}
            var orders = _dbContext.Orders.Where(o => o.UserId == user.Id);
            //throw some error?
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public OrderDto CreateNewOrder(string email, OrderInputModel order)
        {
            //retrieve information from user
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) {throw new Exception("Something went wrong with the database");}
            
            //retrieve information from address
            var address = _dbContext.Addresses.FirstOrDefault(a => a.Id == order.AddressId);
            if(address == null) {throw new Exception("No address found with this addressId");}
            
            //retrive information from paymentcard
            var paymentCard = _dbContext.PaymentCards.FirstOrDefault(p => p.Id == order.PaymentCardId);
            if(paymentCard == null) {throw new Exception("No card found with this PaymentCardId");}

            //shopping cart to calculate total price
            var shoppingCart = _dbContext.ShoppingCart.FirstOrDefault(s => s.UserId == user.Id);
            if(shoppingCart == null) {throw new Exception("This user has no shopping cart");}

            //get all items within shopping cart and loop through them to calculate total price
            float? totalPrice = 0;
            var shoppingCartItems = _dbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == shoppingCart.Id);
            foreach(var shoppingCartItem in shoppingCartItems)
            {
                totalPrice += shoppingCartItem.UnitPrice * shoppingCartItem.Quantity;
            }

            //make the list for the orderdto
            List<OrderItemDto> orderItemList = new List<OrderItemDto>();
            foreach(var shoppingCartItem in shoppingCartItems)
            {
                var orderItemDTO = new OrderItemDto
                {
                    ProductIdentifier = shoppingCartItem.ProductIdentifier,
                    Quantity = shoppingCartItem.Quantity,
                    UnitPrice = shoppingCartItem.UnitPrice,
                    TotalPrice = shoppingCartItem.Quantity * shoppingCartItem.UnitPrice
                };
                orderItemList.Add(orderItemDTO);
            }

            
            //create new order with credit card masked
            var orderEntity = new Order
            {
              Email = email,
              FullName = user.FullName,
              UserId = user.Id,
              StreetName = address.StreetName,
              HouseNumber = address.HouseNumber,
              ZipCode = address.ZipCode,
              Country = address.Country,
              City = address.City,
              CardHolderName = paymentCard.CardholderName,
              MaskedCreditCard = PaymentCardHelper.MaskPaymentCard(paymentCard.CardNumber),
              OrderDate = DateTime.Now,
              TotalPrice = totalPrice,
              //OrderItems = orderItemList
              
            };
            _dbContext.Orders.Add(orderEntity);
            _dbContext.SaveChanges();


            //return order but with credit card unmasked
            var orderDTO = new OrderDto
            {
                Email = email,
                FullName = user.FullName,
                StreetName = address.StreetName,
                HouseNumber = address.HouseNumber,
                ZipCode = address.ZipCode,
                Country = address.Country,
                City = address.City,
                CardholderName = paymentCard.CardholderName,
                CreditCard = paymentCard.CardNumber,
                OrderDate = DateTime.Now.ToString(),
                TotalPrice = totalPrice,
                OrderItems = orderItemList
            };
            //need to create a list of orderitems
            return orderDTO;
        }
    }
}