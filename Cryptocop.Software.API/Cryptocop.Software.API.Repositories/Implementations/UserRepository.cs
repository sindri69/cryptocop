using System;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using System.Linq;
using Cryptocop.Software.API.Repositories.Helpers;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly TokenRepository _tokenRepository;

        public UserRepository(CryptocopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserDto CreateUser(RegisterInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public UserDto AuthenticateUser(LoginInputModel loginInputModel)
        {
            var user = _dbContext.Users.FirstOrDefault(u =>
                u.Email == loginInputModel.Email &&
                u.HashedPassword == HashingHelper.HashPassword(loginInputModel.Password));
            if (user == null) { return null; }
            //throw some exception

            var token = _tokenRepository.CreateNewToken();

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                TokenId = token.Id
            };
        }
    }
}