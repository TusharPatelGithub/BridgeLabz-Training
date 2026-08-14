using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;
using Business.Interfaces;
using Repository.Interfaces;

namespace Business.Services
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IAddressBookRepository repository;

        public AddressBookService(IAddressBookRepository repo)
        {
            repository = repo;
        }

        public async Task<List<AddressBookEntity>> GetAllAsync() => await repository.GetAllAsync();

        public async Task<AddressBookEntity?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

        public async Task<AddressBookEntity> CreateAsync(AddressBookEntity entity) => await repository.AddAsync(entity);

        public async Task<AddressBookEntity?> UpdateAsync(int id, AddressBookEntity entity) => await repository.UpdateAsync(id, entity);

        public async Task<bool> DeleteAsync(int id) => await repository.DeleteAsync(id);
    }
}
