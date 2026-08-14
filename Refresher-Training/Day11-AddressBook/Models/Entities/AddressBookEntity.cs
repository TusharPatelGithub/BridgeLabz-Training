using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public class AddressBookEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation property - EF Core uses this for the FK relationship
        public List<AddressBookModel> Contacts { get; set; } = new List<AddressBookModel>();
    }
}
