using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Cryptocop.Software.API.Middlewares
{
  public static class JwtAuthenticationMiddleware
  {
    public static AuthenticationBuilder AddJwtTokenAuthentication(this AuthenticationBuilder builder, IConfiguration config)
    {
      var jwtConfig = config.GetSection("JwtConfig");
      var secret = jwtConfig.GetValue<string>("secret");
      var issuer = jwtConfig.GetValue<string>("issuer");
      var audience = jwtConfig.GetValue<string>("audience");
      var key = Encoding.ASCII.GetBytes(secret);

      builder.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x => {
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          IssuerSigninKey = new SymmetricSecurityKey(key),
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidIssuer = issuer,
          ValidAudience = audience,
          NameClaimType = "name" //user.identity.name
        };
        x.Events = new JwtBearerEvents
        {
          OnTokenValidated = async context =>
          {
            var claim = context.Principal.Claims.FirstOrDefault(c => c.Type == "tokenId").Value;
            int.TryParse(claim, out var tokenId);
            var accountService = context.HttpContext.RequestServices.GetService<IAccountService>();

            if(accountService.Service.IsTokenBlacklisted(tokenId))
            {
              context.Response.StatusCode = 401;
              await context.Response.WriteAsync("JWT token provided is invalid.");
            }
          }
        }
        
      
      });
      return builder; 

      //muna ad baeta thessu vid i services 120 min i myndbandi 
    } 
    
  }
}