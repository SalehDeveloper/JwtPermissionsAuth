using MyIdentity.Models;

namespace MyIdentity.Authorization
{
    public class UserRoleResponse
    {
        public Guid userId { get; init; }

        public Role Role { get; init; } 
    }

}
