using MyIdentity.Authorization;
using Microsoft.AspNetCore.Authentication;
using MyIdentity.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyIdentity.Authorization
{
    public sealed class CustomClaimsTransformation : IClaimsTransformation
    {
        private readonly IServiceProvider _serviceProvider;

        public CustomClaimsTransformation(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.Identity is not { IsAuthenticated: true } ||
               principal.HasClaim(claim => claim.Type == ClaimTypes.Role) &&
              principal.HasClaim(claim => claim.Type == JwtRegisteredClaimNames.Sub))
            {
                return principal;
            }

            using IServiceScope scope = _serviceProvider.CreateScope();

            var authorizationService = scope.ServiceProvider.GetRequiredService<AuthorizationService>();

            var userId = principal.GetUserId();

            UserRoleResponse userRole = await authorizationService.GetRoleForUserAsync(userId);

            var claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()));

            
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, userRole.Role.Name));
            

            principal.AddIdentity(claimsIdentity);

            return principal;

        }
    }

}
