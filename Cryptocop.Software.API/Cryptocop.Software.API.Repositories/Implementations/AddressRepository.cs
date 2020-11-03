using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Repositories.Contexts;
using System.Linq;
using AutoMapper;
using Cryptocop.Software.API.Models.Entities;
using System;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private IMapper _mapper;

    public AddressRepository(CryptocopDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public void AddAddress(string email, AddressInputModel address)
        {
            var userId = _dbContext.Users.FirstOrDefault(u => u.Email == email).Id;

            var addressEntity = new Address
            {
                StreetName = address.StreetName,
                HouseNumber = address.HouseNumber,
                ZipCode = address.ZipCode,
                Country = address.Country,
                City = address.City,
                UserId = userId
            };
            _dbContext.Addresses.Add(addressEntity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            var userId = _dbContext.Users.FirstOrDefault(u => u.Email == email).Id;
            var addresses = _dbContext.Addresses.Where(i => i.UserId == userId);
            //throw error if there are no addresses?
            //skilar empty enumerable if thetta er tomt
            return _mapper.Map<IEnumerable<AddressDto>>(addresses);
        }

        public void DeleteAddress(string email, int addressId)
        {
            var userId = _dbContext.Users.FirstOrDefault(u => u.Email == email).Id;
            var address = _dbContext.Addresses.FirstOrDefault(a => a.UserId == userId && a.Id == addressId);
            if (address == null) {throw new Exception("Address with this id not found");}
            _dbContext.Addresses.Remove(address);
            _dbContext.SaveChanges();
        }
    }
}