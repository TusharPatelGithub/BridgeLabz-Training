using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Services
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext db;

        public ContactRepository(AppDbContext context)
        {
            db = context;
        }

        public async Task<List<AddressBookModel>> GetAllAsync()
        {
            return await db.Contacts.ToListAsync();
        }

        public async Task<AddressBookModel?> GetByIdAsync(int id)
        {
            return await db.Contacts.FindAsync(id);
        }

        public async Task<List<AddressBookModel>> GetByAddressBookIdAsync(int addressBookId)
        {
            return await db.Contacts
                .Where(c => c.AddressBookEntityId == addressBookId)
                .ToListAsync();
        }

        public async Task<AddressBookModel> AddAsync(AddressBookModel contact)
        {
            db.Contacts.Add(contact);
            await db.SaveChangesAsync();
            return contact;
        }

        public async Task<AddressBookModel?> UpdateAsync(int id, AddressBookModel contact)
        {
            var existing = await db.Contacts.FindAsync(id);
            if (existing == null) return null;

            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.Address = contact.Address;
            existing.City = contact.City;
            existing.State = contact.State;
            existing.Zip = contact.Zip;
            existing.PhoneNumber = contact.PhoneNumber;
            existing.Email = contact.Email;

            await db.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await db.Contacts.FindAsync(id);
            if (existing == null) return false;

            db.Contacts.Remove(existing);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddressBookExistsAsync(int addressBookId)
        {
            return await db.AddressBooks.AnyAsync(b => b.Id == addressBookId);
        }
    }
}
