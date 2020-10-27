using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Cryptocop.Software.API.Models.Dtos;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class TokenService : ITokenService
    {
        public string GenerateJwtToken(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
