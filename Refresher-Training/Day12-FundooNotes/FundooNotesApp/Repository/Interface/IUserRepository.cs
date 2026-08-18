using Repository.Entity;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByResetTokenAsync(string token);
        Task<User> AddAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> EmailExistsAsync(string email);
    }
}
