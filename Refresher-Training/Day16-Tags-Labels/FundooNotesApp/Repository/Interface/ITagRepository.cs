using Repository.Entity;

namespace Repository.Interface
{
    public interface ITagRepository
    {
        Task<Tag> AddAsync(Tag tag);
        Task<Tag?> GetByIdAsync(int tagId);
        Task<List<Tag>> GetAllByUserIdAsync(int userId);
        Task<bool> NameExistsAsync(int userId, string name);
        Task DeleteAsync(Tag tag);
    }
}
