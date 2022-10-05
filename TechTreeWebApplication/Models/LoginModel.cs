using System.ComponentModel.DataAnnotations;

namespace TechTreeWebApplication.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool Success { get; set; } = false;
    }
}
