using Azure.Core;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyIdentity.Authentication;
using MyIdentity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyIdentity.Authentication
{
    public class JwtService : IJwtService
    {
        private readonly AuthenticationOptions _options;

        public JwtService(IOptions< AuthenticationOptions>options)
        {
            _options = options.Value;
        }

        public string GenerateToken(User user)
        {

            var claims = new List<Claim>()
            {

                new Claim(JwtRegisteredClaimNames.Sub , user.Id.ToString()) ,
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()) ,
                new Claim(JwtRegisteredClaimNames.Email , user.Email) ,
                new Claim(JwtRegisteredClaimNames.Name ,user.Name) ,
                new Claim("userid", user.ToString())


            };


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_options.AccessTokenDurationInHours),
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
