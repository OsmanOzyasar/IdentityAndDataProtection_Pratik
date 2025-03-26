using System.ComponentModel.DataAnnotations;

namespace IdentityAndDataProtection_Pratik.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        Admin,
        User
    }
}
