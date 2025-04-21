using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyIdentity.Authentication
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId (this ClaimsPrincipal? principal)
        {
            string? userId = principal?.FindFirstValue("userid");


            return Guid.TryParse(userId, out Guid parsedUserId) ?
                parsedUserId :
                throw new ApplicationException("User id is unavailable");
        }
    }
}
