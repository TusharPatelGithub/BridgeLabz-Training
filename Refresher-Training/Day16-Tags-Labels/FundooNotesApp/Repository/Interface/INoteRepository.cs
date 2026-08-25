using Repository.Entity;

namespace Repository.Interface
{
    public interface INoteRepository
    {
        Task<Note> AddAsync(Note note);
        Task<Note?> GetByIdAsync(int noteId);
        Task<List<Note>> GetAllByUserIdAsync(int userId, string? search, bool? pin, bool? archive, bool? trash);
        Task<Note> UpdateAsync(Note note);
        Task DeleteAsync(Note note);
    }
}
