using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Entity;
using Repository.Interface;

namespace Repository.Service
{
    public class NoteRepositoryImpl : INoteRepository
    {
        private readonly ApplicationDbContext _context;

        public NoteRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Note> AddAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<Note?> GetByIdAsync(int noteId)
        {
            return await _context.Notes
                .Include(n => n.Tags)
                .FirstOrDefaultAsync(n => n.NoteId == noteId);
        }

        public async Task<List<Note>> GetAllByUserIdAsync(int userId, string? search, bool? pin, bool? archive, bool? trash)
        {
            var query = _context.Notes
                .Include(n => n.Tags)
                .Where(n => n.UserId == userId);

            query = trash.HasValue
                ? query.Where(n => n.Trash == trash.Value)
                : query.Where(n => !n.Trash);

            if (pin.HasValue)
            {
                query = query.Where(n => n.Pin == pin.Value);
            }

            if (archive.HasValue)
            {
                query = query.Where(n => n.Archive == archive.Value);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(n =>
                    n.Title.Contains(search) ||
                    (n.Description != null && n.Description.Contains(search)));
            }

            return await query
                .OrderByDescending(n => n.Pin)
                .ThenByDescending(n => n.Created)
                .ToListAsync();
        }

        public async Task<Note> UpdateAsync(Note note)
        {
            note.Edited = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task DeleteAsync(Note note)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }
    }
}
