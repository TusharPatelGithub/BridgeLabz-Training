using Repository.Entity;

namespace Repository.Interface
{
    public interface INoteRepository
    {
        Task<Note> AddAsync(Note note);
        Task<Note?> GetByIdAsync(int noteId);
        Task<List<Note>> GetAllByUserIdAsync(int userId);
        Task DeleteAsync(Note note);
    }
}
