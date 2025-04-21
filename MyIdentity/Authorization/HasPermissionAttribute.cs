using Microsoft.AspNetCore.Authorization;

namespace MyIdentity.Authorization
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string permission)
            : base(permission)
        {

        }
    }

}
