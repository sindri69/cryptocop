﻿using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Repositories.Contexts;
using System.Linq;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CryptocopDbContext _dbContext;

        public AddressRepository(CryptocopDbContext dbContext)
        {
        _dbContext = dbContext;
        }

        public void AddAddress(string email, AddressInputModel address)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            var addresses = _dbContext.Addresses.FirstOrDefault(u => u.Email == inputModel.Email);
            return addresses;
        }

        public void DeleteAddress(string email, int addressId)
        {
            throw new System.NotImplementedException();
        }
    }
}