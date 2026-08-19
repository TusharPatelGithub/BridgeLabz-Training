using AddressBook.Models;

namespace AddressBook.Service.Services;

public interface IAddressBookService
{
    Task<List<AddressBook.Models.AddressBook>> GetAllAsync();

    Task<AddressBook.Models.AddressBook?> GetByIdAsync(int id);

    Task<AddressBook.Models.AddressBook> AddAsync(
        AddressBook.Models.AddressBook contact);

    Task<AddressBook.Models.AddressBook?> UpdateAsync(
        int id,
        AddressBook.Models.AddressBook contact);

    Task<bool> DeleteAsync(int id);

    Task<List<AddressBook.Models.AddressBook>> SearchByCityAsync(
        string city);

    Task<List<AddressBook.Models.AddressBook>> SearchByStateAsync(
        string state);
}