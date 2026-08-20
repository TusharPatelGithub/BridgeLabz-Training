using Business.Interface;
using Models.Dtos;
using Repository.Entity;
using Repository.Interface;

namespace Business.Service
{
    public class NoteServiceImpl : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteServiceImpl(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<NoteResponseDTO> CreateNoteAsync(int userId, CreateNoteDTO createNoteDto)
        {
            var note = new Note
            {
                UserId = userId,
                Title = createNoteDto.Title,
                Description = createNoteDto.Description,
                Reminder = createNoteDto.Reminder,
                Backgroundcolor = createNoteDto.Backgroundcolor,
                Image = createNoteDto.Image,
                Pin = createNoteDto.Pin,
                Archive = createNoteDto.Archive,
                Created = DateTime.UtcNow,
                Edited = DateTime.UtcNow,
                Trash = false
            };

            var savedNote = await _noteRepository.AddAsync(note);
            return MapToResponseDto(savedNote);
        }

        public async Task<List<NoteResponseDTO>> GetAllNotesAsync(int userId)
        {
            var notes = await _noteRepository.GetAllByUserIdAsync(userId);
            return notes.Select(MapToResponseDto).ToList();
        }

        public async Task DeleteNoteAsync(int userId, int noteId)
        {
            var note = await _noteRepository.GetByIdAsync(noteId);

            if (note == null)
            {
                throw new KeyNotFoundException("Note not found");
            }

            if (note.UserId != userId)
            {
                throw new UnauthorizedAccessException("You are not allowed to delete this note");
            }

            await _noteRepository.DeleteAsync(note);
        }

        private static NoteResponseDTO MapToResponseDto(Note note)
        {
            return new NoteResponseDTO
            {
                NoteId = note.NoteId,
                UserId = note.UserId,
                Title = note.Title,
                Description = note.Description,
                Reminder = note.Reminder,
                Backgroundcolor = note.Backgroundcolor,
                Image = note.Image,
                Pin = note.Pin,
                Created = note.Created,
                Edited = note.Edited,
                Trash = note.Trash,
                Archive = note.Archive
            };
        }
    }
}
