using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Models.Dtos;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
        _userRepository = userRepository;
        }

        public UserDto CreateUser(RegisterInputModel inputModel)
        {
            return _userRepository.CreateUser(inputModel);
        }

        public UserDto AuthenticateUser(LoginInputModel loginInputModel)
        {
            throw new System.NotImplementedException();
        }

        public void Logout(int tokenId)
        {
            throw new System.NotImplementedException();
        }
    }
}