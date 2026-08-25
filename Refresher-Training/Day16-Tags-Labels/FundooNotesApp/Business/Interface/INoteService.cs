using Models.Dtos;

namespace Business.Interface
{
    public interface INoteService
    {
        Task<NoteResponseDTO> CreateNoteAsync(int userId, CreateNoteDTO createNoteDto);
        Task<List<NoteResponseDTO>> GetAllNotesAsync(int userId, string? search, bool? pin, bool? archive, bool? trash);
        Task<NoteResponseDTO> TogglePinAsync(int userId, int noteId);
        Task<NoteResponseDTO> ToggleArchiveAsync(int userId, int noteId);
        Task<NoteResponseDTO> ToggleTrashAsync(int userId, int noteId);
        Task<NoteResponseDTO> AddTagToNoteAsync(int userId, int noteId, int tagId);
        Task<NoteResponseDTO> RemoveTagFromNoteAsync(int userId, int noteId, int tagId);
        Task DeleteNoteAsync(int userId, int noteId);
    }
}
