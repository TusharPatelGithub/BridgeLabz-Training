using AddressBook.Repository.Repositories;

namespace AddressBook.Service.Services;

public class AddressBookService : IAddressBookService
{
    private readonly IAddressBookRepository _repository;

    public AddressBookService(IAddressBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AddressBook.Models.AddressBook>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<AddressBook.Models.AddressBook?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<AddressBook.Models.AddressBook> AddAsync(
        AddressBook.Models.AddressBook contact)
    {
        contact.CreatedAt = DateTime.UtcNow;

        return await _repository.AddAsync(contact);
    }

    public async Task<AddressBook.Models.AddressBook?> UpdateAsync(
        int id,
        AddressBook.Models.AddressBook contact)
    {
        return await _repository.UpdateAsync(id, contact);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<List<AddressBook.Models.AddressBook>> SearchByCityAsync(
        string city)
    {
        return await _repository.SearchByCityAsync(city);
    }

    public async Task<List<AddressBook.Models.AddressBook>> SearchByStateAsync(
        string state)
    {
        return await _repository.SearchByStateAsync(state);
    }
}