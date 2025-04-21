namespace MyIdentity.Authentication
{
    public class AuthenticationOptions
    {
        public string Key { get; set; } = string.Empty;

        public string Issuer { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;
        public int AccessTokenDurationInHours { get; set; }
    }
}
