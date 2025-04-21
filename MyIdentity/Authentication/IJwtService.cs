using MyIdentity.Models;

namespace MyIdentity.Authentication
{
    public interface IJwtService
    {
        public string GenerateToken(User user);
    }
}
