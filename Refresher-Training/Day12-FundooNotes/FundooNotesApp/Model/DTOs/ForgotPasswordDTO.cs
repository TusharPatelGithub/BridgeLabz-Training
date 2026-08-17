using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.Model.DTOs
{
    public class ForgotPasswordDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
