namespace MyIdentity
{
    public static  class ApiEndpoints
    {
        private const string ApiBase = "api";
        public static class Users
        {
            private const string Base = $"{ApiBase}/users";

            public const string GetAll = Base;
            
            public const string Create = Base;
        
        }
    }
}
