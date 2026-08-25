using System.ComponentModel.DataAnnotations;

namespace Models.Dtos
{
    public class ResetPasswordDTO
    {
        [Required(ErrorMessage = "Token is required")]
        public string Token { get; set; } = string.Empty;

        [Required(ErrorMessage = "New password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$", ErrorMessage = "Password must be at least 8 characters and include uppercase, lowercase, digit and special character")]
        public string NewPassword { get; set; } = string.Empty;
    }
}
