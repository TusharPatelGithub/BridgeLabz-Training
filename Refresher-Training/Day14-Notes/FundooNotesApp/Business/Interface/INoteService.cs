using Models.Dtos;

namespace Business.Interface
{
    public interface INoteService
    {
        Task<NoteResponseDTO> CreateNoteAsync(int userId, CreateNoteDTO createNoteDto);
        Task<List<NoteResponseDTO>> GetAllNotesAsync(int userId);
        Task DeleteNoteAsync(int userId, int noteId);
    }
}
