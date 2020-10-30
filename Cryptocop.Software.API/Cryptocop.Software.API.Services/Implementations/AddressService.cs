using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Repositories;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class AddressService : IAddressService
    {
        //private AddressRepository _addressRepository;
        public void AddAddress(string email, AddressInputModel address)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            //var addresses = _addressRepository.GetAllAddresses().ToList();
            //return addresses;
            throw new System.NotImplementedException();
        }

        public void DeleteAddress(string email, int addressId)
        {
            throw new System.NotImplementedException();
        }
    }
}