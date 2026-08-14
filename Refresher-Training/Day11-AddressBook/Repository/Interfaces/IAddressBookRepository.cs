using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;

namespace Repository.Interfaces
{
    public interface IAddressBookRepository
    {
        Task<List<AddressBookEntity>> GetAllAsync();
        Task<AddressBookEntity?> GetByIdAsync(int id);
        Task<AddressBookEntity> AddAsync(AddressBookEntity entity);
        Task<AddressBookEntity?> UpdateAsync(int id, AddressBookEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
