using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyIdentity.Authentication;
using System.Text;

namespace MyIdentity.Authentication
{
    public class JwtBearerOptionsSetup : IConfigureNamedOptions<JwtBearerOptions>
    { 
        private readonly AuthenticationOptions _options;

        public JwtBearerOptionsSetup(IOptions< AuthenticationOptions> options)
        {
            _options = options.Value;
        }

     

        public void Configure(JwtBearerOptions options)
        {
            options.Audience = _options.Audience;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _options.Issuer,

                ValidateAudience = true,
                ValidAudience = _options.Audience,

                ValidateLifetime = true,
                RequireExpirationTime = true,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key)),

                ClockSkew = TimeSpan.Zero
            };
        }

        public void Configure(string? name, JwtBearerOptions options)
        {
            Configure(options);
        }
    }
}
