using AddressBook.Models;
using AddressBook.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Repository.Repositories;

public class AddressBookRepository : IAddressBookRepository
{
    private readonly AddressBookDbContext _context;

    public AddressBookRepository(AddressBookDbContext context)
    {
        _context = context;
    }

    public async Task<List<AddressBook.Models.AddressBook>> GetAllAsync()
    {
        return await _context.AddressBooks.ToListAsync();
    }

    public async Task<AddressBook.Models.AddressBook?> GetByIdAsync(int id)
    {
        return await _context.AddressBooks.FindAsync(id);
    }

    public async Task<AddressBook.Models.AddressBook> AddAsync(
        AddressBook.Models.AddressBook contact)
    {
        _context.AddressBooks.Add(contact);
        await _context.SaveChangesAsync();

        return contact;
    }

    public async Task<AddressBook.Models.AddressBook?> UpdateAsync(
        int id,
        AddressBook.Models.AddressBook contact)
    {
        var existingContact = await _context.AddressBooks.FindAsync(id);

        if (existingContact == null)
        {
            return null;
        }

        existingContact.Name = contact.Name;
        existingContact.PhoneNumber = contact.PhoneNumber;
        existingContact.Email = contact.Email;
        existingContact.Address = contact.Address;
        existingContact.City = contact.City;
        existingContact.State = contact.State;
        existingContact.ZipCode = contact.ZipCode;

        await _context.SaveChangesAsync();

        return existingContact;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var contact = await _context.AddressBooks.FindAsync(id);

        if (contact == null)
        {
            return false;
        }

        _context.AddressBooks.Remove(contact);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<AddressBook.Models.AddressBook>> SearchByCityAsync(
        string city)
    {
        return await _context.AddressBooks
            .Where(x => x.City == city)
            .ToListAsync();
    }

    public async Task<List<AddressBook.Models.AddressBook>> SearchByStateAsync(
        string state)
    {
        return await _context.AddressBooks
            .Where(x => x.State == state)
            .ToListAsync();
    }
}