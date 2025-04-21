using MyIdentity.Authorization;
using MyIdentity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyIdentity.Data;

namespace MyIdentity.Controllers
{
    
    [ApiController]
    public class UsersContoller : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public UsersContoller(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet(ApiEndpoints.Users.GetAll)]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.Include(x=> x.Role).ToListAsync();

            var response = users.Select(x => new
            { 
                x.Id,
                x.Name,
                RoleName = x.Role.Name

            });
            return Ok(response);
        }



        [HasPermission("CreateUser")]
        [HttpPost(ApiEndpoints.Users.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var user = new User(request.Name, request.Email, request.Password);

            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name.ToLower() == request.RoleName.ToLower());

            user.RoleId = role.Id;

            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            
            return Ok();
        }
    }

    public class CreateUserRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string RoleName { get; set; }

    }
}
