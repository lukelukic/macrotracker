using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MacroTracker.Users.Application.UseCases
{
    public class RegisterUserUseCase : IRequest
    {
        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression("^[a-zA-Z][a-zA-Z0-9]{5,11}$", ErrorMessage = "Invalid username format.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [RegularExpression("^[A-Z][a-z]{2,12}$", ErrorMessage = "Invalid frist name format. Example: Pera")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]{2,12}$")]
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }
    }
}