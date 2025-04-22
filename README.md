# JwtPermissionsAuth

🚀 A clean and extensible ASP.NET Core Web API project demonstrating:

- ✅ JWT Authentication
- ✅ Role-based Authorization
- ✅ Permission-based Authorization
- ✅ Custom Claims Transformation
- ✅ Custom Policy Provider & Authorization Handler
- ✅ EF Core with Fluent API Configurations

## 🔧 Features

- Users have one Role 
- Roles have many Permissions (many-to-many)
- Permissions are dynamically resolved using custom policies
- Secure endpoints using `[HasPermission("PermissionName")]` attribute

> ⚠️ **Note:** This structure is not necessarily the best or production-ready architecture.  
> The goal of this project is to **demonstrate how to implement role and permission-based authorization** in a clear and educational way.
