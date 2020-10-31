using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly ITokenRepository _TokenRepository;

        public JwtTokenService(ITokenRepository tokenRepository)
        {
        _TokenRepository = tokenRepository;
        }

        public bool IsTokenBlacklisted(int tokenId)
        {
            return _TokenRepository.IsTokenBlacklisted(tokenId);
        }
    }
}