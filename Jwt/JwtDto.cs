using IdentityAndDataProtection_Pratik.Entities;

namespace IdentityAndDataProtection_Pratik.Jwt
{
    public class JwtDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireMinute { get; set; }
    }
}
