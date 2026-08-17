using FundooNotesApp.Model.DTOs;

namespace FundooNotesApp.Service
{
    public interface IUserService
    {
        Task<UserResponseDTO> RegisterAsync(RegisterDTO registerDto);
        Task<LoginResponseDTO> LoginAsync(LoginDTO loginDto);
        Task<string> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDto);
        Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDto);
    }
}
