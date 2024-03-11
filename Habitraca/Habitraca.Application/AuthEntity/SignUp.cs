using Habitraca.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Habitraca.Application.AuthEntity
{
    public class SignUp
    {
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "PhoneNumber address is required.")]

        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password address is required.")]
       
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set;}
        public string? Address { get; set;}

        [Required(ErrorMessage = "StateOfOrigin is required.")]
        public string? StateOfOrigin { get; set; }
        public string? LGA { get; set;}

        [Required(ErrorMessage = "Country is required.")]
        public string? Country { get; set;}

        [Required(ErrorMessage = "StateOfResidence is required.")]
       
        public string? StateOfResidence { get; set;}
        public Gender Gender { get; set;}

    }
}
