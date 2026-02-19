using System.Collections.Generic;
namespace BridgeLabz.AddressBookSystem
{
    public interface IDataSource
    {
        void Save(string addressBookName, List<AddressBookModel> contacts);
        List<AddressBookModel> Load(string addressBookName);
    }
}
