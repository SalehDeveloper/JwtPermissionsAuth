using Microsoft.EntityFrameworkCore;
using MyIdentity.Data;

namespace MyIdentity.Authorization
{
    public class AuthorizationService
    {

        private readonly ApplicationDbContext _context;

        public AuthorizationService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<UserRoleResponse> GetRoleForUserAsync (Guid userId)
        {
            var user =await  _context.Users.FindAsync(userId);

            if (user == null) 
                 return new UserRoleResponse { userId=Guid.Empty  , Role = null };

            var role =await _context.Roles.Include(r=>r.Permissions).FirstOrDefaultAsync(r => r.Id == user.RoleId);

            return new UserRoleResponse { userId = user.Id, Role = role };

        }

        
    }
}
