using FundooNotesApp.Helpers;
using FundooNotesApp.Model;
using FundooNotesApp.Model.DTOs;
using FundooNotesApp.Repository;

namespace FundooNotesApp.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtHelper _jwtHelper;

        public UserService(IUserRepository userRepository, JwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
        }

        public async Task<UserResponseDTO> RegisterAsync(RegisterDTO registerDto)
        {
            var emailExists = await _userRepository.EmailExistsAsync(registerDto.Email);
            if (emailExists)
            {
                throw new InvalidOperationException("Email is already registered");
            }

            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                Password = PasswordHelper.HashPassword(registerDto.Password)
            };

            var createdUser = await _userRepository.AddAsync(user);

            return new UserResponseDTO
            {
                Id = createdUser.Id,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email
            };
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null || !PasswordHelper.VerifyPassword(loginDto.Password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }

            var token = _jwtHelper.GenerateToken(user);

            return new LoginResponseDTO
            {
                Token = token,
                User = new UserResponseDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                }
            };
        }

        public async Task<string> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDto)
        {
            var user = await _userRepository.GetByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
            {
                throw new KeyNotFoundException("No account found with this email");
            }

            var resetToken = Guid.NewGuid().ToString("N");
            user.ResetToken = resetToken;
            user.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(30);

            await _userRepository.UpdateAsync(user);

            return resetToken;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDto)
        {
            var user = await _userRepository.GetByResetTokenAsync(resetPasswordDto.Token);
            if (user == null || user.ResetTokenExpiry == null || user.ResetTokenExpiry < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Reset token is invalid or expired");
            }

            user.Password = PasswordHelper.HashPassword(resetPasswordDto.NewPassword);
            user.ResetToken = null;
            user.ResetTokenExpiry = null;

            return await _userRepository.UpdateAsync(user);
        }
    }
}
