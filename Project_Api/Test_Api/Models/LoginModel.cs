using System.ComponentModel.DataAnnotations;

namespace Test_Api.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = null!;
    }
}
