using Business.Interface;
using Models.Dtos;
using Repository.Entity;
using Repository.Interface;

namespace Business.Service
{
    public class NoteServiceImpl : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ITagRepository _tagRepository;

        public NoteServiceImpl(INoteRepository noteRepository, ITagRepository tagRepository)
        {
            _noteRepository = noteRepository;
            _tagRepository = tagRepository;
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

        public async Task<NoteResponseDTO> AddTagToNoteAsync(int userId, int noteId, int tagId)
        {
            var note = await GetOwnedNoteAsync(userId, noteId);
            var tag = await _tagRepository.GetByIdAsync(tagId);

            if (tag == null)
            {
                throw new KeyNotFoundException("Tag not found");
            }

            if (tag.UserId != userId)
            {
                throw new UnauthorizedAccessException("You are not allowed to use this tag");
            }

            if (!note.Tags.Any(t => t.TagId == tagId))
            {
                note.Tags.Add(tag);
                await _noteRepository.UpdateAsync(note);
            }

            return MapToResponseDto(note);
        }

        public async Task<NoteResponseDTO> RemoveTagFromNoteAsync(int userId, int noteId, int tagId)
        {
            var note = await GetOwnedNoteAsync(userId, noteId);
            var tagToRemove = note.Tags.FirstOrDefault(t => t.TagId == tagId);

            if (tagToRemove != null)
            {
                note.Tags.Remove(tagToRemove);
                await _noteRepository.UpdateAsync(note);
            }

            return MapToResponseDto(note);
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
                Archive = note.Archive,
                Tags = note.Tags.Select(t => new TagResponseDTO { TagId = t.TagId, Name = t.Name }).ToList()
            };
        }
    }
}
