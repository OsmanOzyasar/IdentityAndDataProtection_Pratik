using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityAndDataProtection_Pratik.Models
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
