using Microsoft.AspNetCore.Authorization;

namespace MyIdentity.Authorization
{
    public class PermissionRequirment : IAuthorizationRequirement
    {
        public string Permission { get; }

        public PermissionRequirment(string permission)
        {
            Permission = permission;
        }
    }

}
