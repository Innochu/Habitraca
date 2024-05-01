using System.ComponentModel.DataAnnotations;

namespace Habitraca.Application.DtoFolder
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
