using System.ComponentModel.DataAnnotations;

namespace Models.Dtos
{
    public class ForgotPasswordDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; } = string.Empty;
    }
}
