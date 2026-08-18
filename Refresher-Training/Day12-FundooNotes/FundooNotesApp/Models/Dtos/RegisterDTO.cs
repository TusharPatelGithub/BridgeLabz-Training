using System.ComponentModel.DataAnnotations;

namespace Models.Dtos
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[A-Za-z]{2,30}$", ErrorMessage = "First name must contain only letters (2-30 characters)")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[A-Za-z]{2,30}$", ErrorMessage = "Last name must contain only letters (2-30 characters)")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$", ErrorMessage = "Password must be at least 8 characters and include uppercase, lowercase, digit and special character")]
        public string Password { get; set; } = string.Empty;
    }
}
