using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Entity;
using Repository.Interface;

namespace Repository.Service
{
    public class TagRepositoryImpl : ITagRepository
    {
        private readonly ApplicationDbContext _context;

        public TagRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> GetByIdAsync(int tagId)
        {
            return await _context.Tags
                .Include(t => t.Notes)
                .FirstOrDefaultAsync(t => t.TagId == tagId);
        }

        public async Task<List<Tag>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Tags
                .Where(t => t.UserId == userId)
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<bool> NameExistsAsync(int userId, string name)
        {
            return await _context.Tags.AnyAsync(t => t.UserId == userId && t.Name == name);
        }

        public async Task DeleteAsync(Tag tag)
        {
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }
    }
}
