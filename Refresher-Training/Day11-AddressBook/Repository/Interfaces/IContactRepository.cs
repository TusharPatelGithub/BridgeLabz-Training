using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;

namespace Repository.Interfaces
{
    public interface IContactRepository
    {
        Task<List<AddressBookModel>> GetAllAsync();
        Task<AddressBookModel?> GetByIdAsync(int id);
        Task<List<AddressBookModel>> GetByAddressBookIdAsync(int addressBookId);
        Task<AddressBookModel> AddAsync(AddressBookModel contact);
        Task<AddressBookModel?> UpdateAsync(int id, AddressBookModel contact);
        Task<bool> DeleteAsync(int id);
        Task<bool> AddressBookExistsAsync(int addressBookId);
    }
}
