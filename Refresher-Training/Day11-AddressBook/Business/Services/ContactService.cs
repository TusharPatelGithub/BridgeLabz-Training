using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;
using Business.Interfaces;
using Repository.Interfaces;

namespace Business.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository repository;

        public ContactService(IContactRepository repo)
        {
            repository = repo;
        }

        public async Task<List<AddressBookModel>> GetAllAsync() => await repository.GetAllAsync();

        public async Task<AddressBookModel?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

        public async Task<List<AddressBookModel>> GetByAddressBookIdAsync(int addressBookId) =>
            await repository.GetByAddressBookIdAsync(addressBookId);

        public async Task<(AddressBookModel? Contact, string? Error)> CreateAsync(AddressBookModel contact)
        {
            bool bookExists = await repository.AddressBookExistsAsync(contact.AddressBookEntityId);
            if (!bookExists)
                return (null, $"Address Book with Id {contact.AddressBookEntityId} does not exist.");

            var created = await repository.AddAsync(contact);
            return (created, null);
        }

        public async Task<AddressBookModel?> UpdateAsync(int id, AddressBookModel contact) =>
            await repository.UpdateAsync(id, contact);

        public async Task<bool> DeleteAsync(int id) => await repository.DeleteAsync(id);
    }
}
