using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Services
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private readonly AppDbContext db;

        public AddressBookRepository(AppDbContext context)
        {
            db = context;
        }

        public async Task<List<AddressBookEntity>> GetAllAsync()
        {
            return await db.AddressBooks.ToListAsync();
        }

        public async Task<AddressBookEntity?> GetByIdAsync(int id)
        {
            return await db.AddressBooks.FindAsync(id);
        }

        public async Task<AddressBookEntity> AddAsync(AddressBookEntity entity)
        {
            db.AddressBooks.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<AddressBookEntity?> UpdateAsync(int id, AddressBookEntity entity)
        {
            var existing = await db.AddressBooks.FindAsync(id);
            if (existing == null) return null;

            existing.Name = entity.Name;
            await db.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await db.AddressBooks.FindAsync(id);
            if (existing == null) return false;

            db.AddressBooks.Remove(existing);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
