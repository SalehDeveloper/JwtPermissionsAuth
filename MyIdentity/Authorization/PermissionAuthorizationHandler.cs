using Microsoft.AspNetCore.Authorization;
using MyIdentity.Authentication;

namespace MyIdentity.Authorization
{
    public sealed class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirment>
    {
        private readonly IServiceProvider _serviceProvider;

        public PermissionAuthorizationHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirment requirement)
        {
            if (context.User.Identity is not { IsAuthenticated: true })
            {
                return;
            }


            using IServiceScope scope = _serviceProvider.CreateScope();

            var auhtrizationService = scope.ServiceProvider.GetRequiredService<AuthorizationService>();

            var userId = context.User.GetUserId();

            var userRoleResponse = await auhtrizationService.GetRoleForUserAsync(userId);

            var RoleName = userRoleResponse.Role.Name;
            
            var permissions = userRoleResponse.Role.Permissions.Select(p => p.Name).ToList();

            permissions.Add(RoleName);
          
            if (permissions.Contains(requirement.Permission))
            {
                context.Succeed(requirement);
            }

        }
    }

}
