using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;

namespace Business.Interfaces
{
    public interface IAddressBookService
    {
        Task<List<AddressBookEntity>> GetAllAsync();
        Task<AddressBookEntity?> GetByIdAsync(int id);
        Task<AddressBookEntity> CreateAsync(AddressBookEntity entity);
        Task<AddressBookEntity?> UpdateAsync(int id, AddressBookEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
