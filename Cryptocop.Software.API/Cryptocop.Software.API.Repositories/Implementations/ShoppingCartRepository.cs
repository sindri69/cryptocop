using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using AutoMapper;
using System.Linq;
using System;
using Cryptocop.Software.API.Models.Entities;

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

        public void AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItem, float priceInUsd)
        {
            //Console.WriteLine("start of add");
            //Console.WriteLine(email);
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            Console.WriteLine("before user null check");
            if(user == null) {throw new Exception("something went wrong with the database (userid)");}

            Console.WriteLine("before getting shopping cart");
            var shoppingCart = _dbContext.ShoppingCart.FirstOrDefault(s => s.UserId == user.Id);
            Console.WriteLine("after getting shopping cart");
            if(shoppingCart == null) 
            {
                shoppingCart = new ShoppingCart
                {
                    UserId = user.Id
                };
                _dbContext.ShoppingCart.Add(shoppingCart);
                _dbContext.SaveChanges();
                Console.WriteLine("inside null check");
            }
            Console.WriteLine("after null check");
        
            var shoppingCartItemEntity = new ShoppingCartItem
            {
                ProductIdentifier = shoppingCartItem.ProductIdentifier,
                Quantity = shoppingCartItem.Quantity,
                UnitPrice = priceInUsd,
                ShoppingCartId = shoppingCart.Id
            };

            _dbContext.ShoppingCartItems.Add(shoppingCartItemEntity);
            _dbContext.SaveChanges();
            Console.WriteLine("end of add");

        }

        public void RemoveCartItem(string email, int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) {throw new Exception("something went wrong with the database (userid)");}

            var shoppingCart = _dbContext.ShoppingCart.FirstOrDefault(s => s.UserId == user.Id);
            if(user == null) {throw new Exception("something went wrong with the database (shoppingcart)");}

            var removedItem = _dbContext.ShoppingCartItems.FirstOrDefault(s => s.Id == id && s.ShoppingCartId == shoppingCart.Id);
            if(removedItem == null) {throw new Exception("There is not item with this id in your cart");}
            //throw some kind of exception?

            _dbContext.ShoppingCartItems.Remove(removedItem);
            _dbContext.SaveChanges();
        }

        public void UpdateCartItemQuantity(string email, int id, float quantity)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) {throw new Exception("something went wrong with the database (userid)");}

            var shoppingCart = _dbContext.ShoppingCart.FirstOrDefault(s => s.UserId == user.Id);
            if(user == null) {throw new Exception("This user has no shopping cart");}

            var updatedItem = _dbContext.ShoppingCartItems.FirstOrDefault(s => s.Id == id && s.ShoppingCartId == shoppingCart.Id);
            if(updatedItem == null) {throw new Exception("There is not item with this id in your cart");}
            updatedItem.Quantity = quantity;
            
            _dbContext.ShoppingCartItems.Update(updatedItem);
            _dbContext.SaveChanges();
        }

        public void ClearCart(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) {throw new Exception("something went wrong with the database (userid)");}
            
            var shoppingCart = _dbContext.ShoppingCart.FirstOrDefault(s => s.UserId == user.Id);
            if(user == null) {throw new Exception("This user has no shopping cart");}

            var shoppingCartItems = _dbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == shoppingCart.Id);

            _dbContext.ShoppingCartItems.RemoveRange(shoppingCartItems);
            _dbContext.SaveChanges();
        }

        public void DeleteCart(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) {throw new Exception("something went wrong with the database (userid)");}

            var shoppingCart = _dbContext.ShoppingCart.FirstOrDefault(s => s.UserId == user.Id);
            if(shoppingCart == null) {throw new Exception("This user has no shopping cart");}
            
            _dbContext.ShoppingCart.Remove(shoppingCart);
            _dbContext.SaveChanges();
        }
    }
}