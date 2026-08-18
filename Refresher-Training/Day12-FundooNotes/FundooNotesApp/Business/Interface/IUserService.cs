using Models.Dtos;

namespace Business.Interface
{
    public interface IUserService
    {
        Task<UserResponseDTO> RegisterAsync(RegisterDTO registerDto);
        Task<LoginResponseDTO> LoginAsync(LoginDTO loginDto);
        Task<string> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDto);
        Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDto);
    }
}
