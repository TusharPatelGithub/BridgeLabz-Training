using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;

namespace Business.Interfaces
{
    public interface IContactService
    {
        Task<List<AddressBookModel>> GetAllAsync();
        Task<AddressBookModel?> GetByIdAsync(int id);
        Task<List<AddressBookModel>> GetByAddressBookIdAsync(int addressBookId);
        Task<(AddressBookModel? Contact, string? Error)> CreateAsync(AddressBookModel contact);
        Task<AddressBookModel?> UpdateAsync(int id, AddressBookModel contact);
        Task<bool> DeleteAsync(int id);
    }
}
