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

        public async Task<List<NoteResponseDTO>> GetAllNotesAsync(int userId, string? search, bool? pin, bool? archive, bool? trash)
        {
            var notes = await _noteRepository.GetAllByUserIdAsync(userId, search, pin, archive, trash);
            return notes.Select(MapToResponseDto).ToList();
        }

        public async Task<NoteResponseDTO> TogglePinAsync(int userId, int noteId)
        {
            var note = await GetOwnedNoteAsync(userId, noteId);
            note.Pin = !note.Pin;
            var updated = await _noteRepository.UpdateAsync(note);
            return MapToResponseDto(updated);
        }

        public async Task<NoteResponseDTO> ToggleArchiveAsync(int userId, int noteId)
        {
            var note = await GetOwnedNoteAsync(userId, noteId);
            note.Archive = !note.Archive;
            var updated = await _noteRepository.UpdateAsync(note);
            return MapToResponseDto(updated);
        }

        public async Task<NoteResponseDTO> ToggleTrashAsync(int userId, int noteId)
        {
            var note = await GetOwnedNoteAsync(userId, noteId);
            note.Trash = !note.Trash;
            var updated = await _noteRepository.UpdateAsync(note);
            return MapToResponseDto(updated);
        }

        public async Task DeleteNoteAsync(int userId, int noteId)
        {
            var note = await GetOwnedNoteAsync(userId, noteId);
            await _noteRepository.DeleteAsync(note);
        }

        private async Task<Note> GetOwnedNoteAsync(int userId, int noteId)
        {
            var note = await _noteRepository.GetByIdAsync(noteId);

            if (note == null)
            {
                throw new KeyNotFoundException("Note not found");
            }

            if (note.UserId != userId)
            {
                throw new UnauthorizedAccessException("You are not allowed to modify this note");
            }

            return note;
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
