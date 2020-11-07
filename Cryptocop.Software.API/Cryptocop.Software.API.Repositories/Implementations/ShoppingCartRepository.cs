using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using AutoMapper;
using System.Linq;
using System;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private IMapper _mapper;

        public ShoppingCartRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
        _dbContext = dbContext;
        _mapper = mapper;
        }

        public IEnumerable<ShoppingCartItemDto> GetCartItems(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            
            if(user == null) {throw new Exception("Something went wrong with the database (userid)");}
            var shoppingCart = _dbContext.ShoppingCart.FirstOrDefault(s => s.UserId == user.Id);

            if(shoppingCart == null) {throw new Exception("Something went wrong with the database (shoppingCart)");}
            var shoppingCartItems = _dbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == shoppingCart.Id);
            
            //skilar empty enumerable if thetta er tomt
            return _mapper.Map<IEnumerable<ShoppingCartItemDto>>(shoppingCartItems);
        }

        public void AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemItem, float priceInUsd)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCartItem(string email, int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCartItemQuantity(string email, int id, float quantity)
        {
            throw new System.NotImplementedException();
        }

        public void ClearCart(string email)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCart(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}