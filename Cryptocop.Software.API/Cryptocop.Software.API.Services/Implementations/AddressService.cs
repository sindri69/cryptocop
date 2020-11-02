using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Repositories;
using Cryptocop.Software.API.Repositories.Implementations;
using System.Linq;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
        _addressRepository = addressRepository;
        }

    public void AddAddress(string email, AddressInputModel address)
        {
            _addressRepository.AddAddress(email, address);
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            var addresses = _addressRepository.GetAllAddresses(email).ToList();
            return addresses;
            
        }

        public void DeleteAddress(string email, int addressId)
        {
            throw new System.NotImplementedException();
        }
    }
}