using System;
using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using AutoMapper;
using System.Linq;

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
            var addresses = _dbContext.Addresses.Where(i => i.UserId == user.Id);
            //throw some error

            //retrive information from paymentcard
            var paymentCards = _dbContext.PaymentCards.Where(p => p.UserId == user.Id);
            //throw some error

            //create new order with credit card masked
            //return order but with credit card unmasked
            throw new NotImplementedException();
        }
    }
}