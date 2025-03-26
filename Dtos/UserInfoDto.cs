using IdentityAndDataProtection_Pratik.Entities;

namespace IdentityAndDataProtection_Pratik.Dtos
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
    }
}
