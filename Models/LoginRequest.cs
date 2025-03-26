using System.ComponentModel.DataAnnotations;

namespace IdentityAndDataProtection_Pratik.Models
{
    public class LoginRequest
    {
        [Required]
        [MaxLength(355)]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
