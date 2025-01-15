using System.ComponentModel.DataAnnotations;

namespace Habitraca.Domain.AuthEntity
{
    public class Login
    {
        [Required(ErrorMessage = "Enter Username/Email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; } = string.Empty;

    }
}
