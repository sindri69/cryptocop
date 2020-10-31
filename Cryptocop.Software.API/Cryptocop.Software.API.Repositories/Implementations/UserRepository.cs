using System;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using System.Linq;
using Cryptocop.Software.API.Repositories.Helpers;
using Cryptocop.Software.API.Models.Entities;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly ITokenRepository _tokenRepository;

        public UserRepository(CryptocopDbContext dbContext, ITokenRepository tokenRepository)
        {
        _dbContext = dbContext;
        _tokenRepository = tokenRepository;
        }

    public UserDto CreateUser(RegisterInputModel inputModel)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == inputModel.Email);
            Console.WriteLine(inputModel.Email);
            Console.WriteLine("user", user.IsEmpty());
            //check if a user with this email exists
            if(user != null) {throw new Exception("A user with this email already exists");}
            Console.WriteLine(inputModel.Email);

            var userEntity = new User
            {
                //id = id??
                FullName = inputModel.FullName,
                Email = inputModel.Email,
                HashedPassword = HashingHelper.HashPassword(inputModel.Password)

            };
            _dbContext.Users.Add(userEntity);
            _dbContext.SaveChanges();

            return new UserDto 
            {
                Id = _dbContext.Users.FirstOrDefault(u => u.Email == inputModel.Email).Id,
                FullName = userEntity.FullName,
                Email = userEntity.Email,
                TokenId = _tokenRepository.CreateNewToken().Id
            };
            

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