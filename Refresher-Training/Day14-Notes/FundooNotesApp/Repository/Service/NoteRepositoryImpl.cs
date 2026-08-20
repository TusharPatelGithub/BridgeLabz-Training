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
            return await _context.Notes.FirstOrDefaultAsync(n => n.NoteId == noteId);
        }

        public async Task<List<Note>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId && !n.Trash)
                .OrderByDescending(n => n.Pin)
                .ThenByDescending(n => n.Created)
                .ToListAsync();
        }

        public async Task DeleteAsync(Note note)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }
    }
}
