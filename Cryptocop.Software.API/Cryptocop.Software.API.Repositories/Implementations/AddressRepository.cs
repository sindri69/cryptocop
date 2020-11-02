using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Repositories.Contexts;
using System.Linq;
using AutoMapper;
using Cryptocop.Software.API.Models.Entities;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private IMapper _mapper;

        public AddressRepository(CryptocopDbContext dbContext)
        {
        _dbContext = dbContext;
        }

        public void AddAddress(string email, AddressInputModel address)
        {
            var userId = _dbContext.Users.FirstOrDefault(u => u.Email == email).Id;

            var addressEntity = new Address
            {
                StreetName = address.StreetName,
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
            return _mapper.Map<IEnumerable<AddressDto>>(addresses);
        }

        public void DeleteAddress(string email, int addressId)
        {
            throw new System.NotImplementedException();
        }
    }
}